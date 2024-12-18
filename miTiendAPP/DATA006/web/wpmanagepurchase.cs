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
   public class wpmanagepurchase : GXDataArea
   {
      public wpmanagepurchase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpmanagepurchase( IGxContext context )
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
         dynavSupplier = new GXCombobox();
         cmbavOrderby = new GXCombobox();
         chkavDescending = new GXCheckbox();
         chkavIsowed = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSUPPLIER") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSUPPLIER222( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpurchaseordersfiltered") == 0 )
            {
               gxnrGridpurchaseordersfiltered_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridpurchaseordersfiltered") == 0 )
            {
               gxgrGridpurchaseordersfiltered_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fgridedit") == 0 )
            {
               gxnrFgridedit_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fgridedit") == 0 )
            {
               gxgrFgridedit_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fgridposiblenewdetails") == 0 )
            {
               gxnrFgridposiblenewdetails_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fgridposiblenewdetails") == 0 )
            {
               gxgrFgridposiblenewdetails_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fgridcancel") == 0 )
            {
               gxnrFgridcancel_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fgridcancel") == 0 )
            {
               gxgrFgridcancel_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               gxnrGrid2_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               gxgrGrid2_refresh_invoke( ) ;
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

      protected void gxnrGridpurchaseordersfiltered_newrow_invoke( )
      {
         nRC_GXsfl_41 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_41"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_41_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_41_idx = GetPar( "sGXsfl_41_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpurchaseordersfiltered_newrow( ) ;
         /* End function gxnrGridpurchaseordersfiltered_newrow_invoke */
      }

      protected void gxgrGridpurchaseordersfiltered_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         AV69PurchaseOrderIdAux = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderIdAux"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV26FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
         AV27ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
         cmbavOrderby.FromJSonString( GetNextPar( ));
         AV52OrderBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderBy"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         AV99IsOwed = StringUtil.StrToBool( GetPar( "IsOwed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridpurchaseordersfiltered_refresh_invoke */
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_101 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_101"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_101_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_101_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_101_idx = GetPar( "sGXsfl_101_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         AV99IsOwed = StringUtil.StrToBool( GetPar( "IsOwed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected void gxnrFgridedit_newrow_invoke( )
      {
         nRC_GXsfl_161 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_161"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_161_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_161_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_161_idx = GetPar( "sGXsfl_161_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFgridedit_newrow( ) ;
         /* End function gxnrFgridedit_newrow_invoke */
      }

      protected void gxgrFgridedit_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         AV99IsOwed = StringUtil.StrToBool( GetPar( "IsOwed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFgridedit_refresh_invoke */
      }

      protected void gxnrFgridposiblenewdetails_newrow_invoke( )
      {
         nRC_GXsfl_208 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_208"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_208_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_208_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_208_idx = GetPar( "sGXsfl_208_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFgridposiblenewdetails_newrow( ) ;
         /* End function gxnrFgridposiblenewdetails_newrow_invoke */
      }

      protected void gxgrFgridposiblenewdetails_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         AV99IsOwed = StringUtil.StrToBool( GetPar( "IsOwed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFgridposiblenewdetails_refresh_invoke */
      }

      protected void gxnrFgridcancel_newrow_invoke( )
      {
         nRC_GXsfl_263 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_263"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_263_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_263_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_263_idx = GetPar( "sGXsfl_263_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrFgridcancel_newrow( ) ;
         /* End function gxnrFgridcancel_newrow_invoke */
      }

      protected void gxgrFgridcancel_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         AV99IsOwed = StringUtil.StrToBool( GetPar( "IsOwed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrFgridcancel_refresh_invoke */
      }

      protected void gxnrGrid2_newrow_invoke( )
      {
         nRC_GXsfl_303 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_303"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_303_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_303_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_303_idx = GetPar( "sGXsfl_303_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid2_newrow( ) ;
         /* End function gxnrGrid2_newrow_invoke */
      }

      protected void gxgrGrid2_refresh_invoke( )
      {
         subGridpurchaseordersfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridpurchaseordersfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV24Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         AV53Descending = StringUtil.StrToBool( GetPar( "Descending"));
         AV99IsOwed = StringUtil.StrToBool( GetPar( "IsOwed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid2_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid2_refresh_invoke */
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

      public override short ExecuteStartEvent( )
      {
         PA222( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START222( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpmanagepurchase.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Detailsregister", AV61DetailsRegister);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Detailsregister", AV61DetailsRegister);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Detailsedit", AV59DetailsEdit);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Detailsedit", AV59DetailsEdit);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Posiblesnewdetails", AV65PosiblesNewDetails);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Posiblesnewdetails", AV65PosiblesNewDetails);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Detailscancel", AV60DetailsCancel);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Detailscancel", AV60DetailsCancel);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Detailspay", AV101DetailsPay);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Detailspay", AV101DetailsPay);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtpurchaseordergeneratelist", AV46SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtpurchaseordergeneratelist", AV46SDTPurchaseOrderGenerateList);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_101", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_101), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_161", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_161), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_208", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_208), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_263", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_263), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_303", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_303), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55PurchaseOrderId), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDETAILSREGISTER", AV61DetailsRegister);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDETAILSREGISTER", AV61DetailsRegister);
         }
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPPLIEREMAIL", A8SupplierEmail);
         GxWebStd.gx_hidden_field( context, "SUPPLIERNAME", A5SupplierName);
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERCREATEDDATE", context.localUtil.DToC( A52PurchaseOrderCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERTOTALPAID", StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "vEMAILPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90EmailPurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vEMAILBODY", AV76EmailBody);
         GxWebStd.gx_hidden_field( context, "vEMAILSUPPLIEREMAIL", AV91EmailSupplierEmail);
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV54AllOk);
         GxWebStd.gx_hidden_field( context, "vEMAILCREATEDDATE", context.localUtil.DToC( AV87EmailCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vEMAILTOTALPAID", StringUtil.LTrim( StringUtil.NToC( AV88EmailTotalPaid, 18, 2, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDETAILSEDIT", AV59DetailsEdit);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDETAILSEDIT", AV59DetailsEdit);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPURCHASEORDERGENERATELIST", AV46SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPURCHASEORDERGENERATELIST", AV46SDTPurchaseOrderGenerateList);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCONTROLPASSED", AV71ControlPassed);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPOSIBLESNEWDETAILS", AV65PosiblesNewDetails);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPOSIBLESNEWDETAILS", AV65PosiblesNewDetails);
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Collapsed), 1, 0, ".", "")));
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
            WE222( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT222( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wpmanagepurchase.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPManagePurchase" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPManage Purchase" ;
      }

      protected void WB220( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Manage Purchase Orders", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-02", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPurchaseorderidaux_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPurchaseorderidaux_Internalname, "Nro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPurchaseorderidaux_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69PurchaseOrderIdAux), 6, 0, ".", "")), StringUtil.LTrim( ((edtavPurchaseorderidaux_Enabled!=0) ? context.localUtil.Format( (decimal)(AV69PurchaseOrderIdAux), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV69PurchaseOrderIdAux), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPurchaseorderidaux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPurchaseorderidaux_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSupplier_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSupplier_Internalname, "Supplier", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_41_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_WPManagePurchase.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", (string)(dynavSupplier.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFromdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromdate_Internalname, "From Date", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_41_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV26FromDate, "99/99/99"), context.localUtil.Format( AV26FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPManagePurchase.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPManagePurchase.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTodate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTodate_Internalname, "To Date", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_41_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV27ToDate, "99/99/99"), context.localUtil.Format( AV27ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPManagePurchase.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPManagePurchase.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOrderby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderby_Internalname, "Order By", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_41_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderby, cmbavOrderby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0)), 1, cmbavOrderby_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOrderby.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 0, "HLP_WPManagePurchase.htm");
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
            AssignProp("", false, cmbavOrderby_Internalname, "Values", (string)(cmbavOrderby.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDescending_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDescending_Internalname, "Desc", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_41_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDescending_Internalname, StringUtil.BoolToStr( AV53Descending), "", "Desc", 1, chkavDescending.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /*  Grid Control  */
            GridpurchaseordersfilteredContainer.SetWrapped(nGXWrapped);
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nEOF", GRIDPURCHASEORDERSFILTERED_nEOF);
               GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
               AV112GXV1 = nGXsfl_41_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridpurchaseordersfilteredContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpurchaseordersfiltered", GridpurchaseordersfilteredContainer, subGridpurchaseordersfiltered_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData", GridpurchaseordersfilteredContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData"+"V", GridpurchaseordersfilteredContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpurchaseordersfilteredContainerData"+"V"+"\" value='"+GridpurchaseordersfilteredContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, divTableregister_Internalname, divTableregister_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonsregister_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotalpaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalpaid_Internalname, "Total Paid", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalpaid_Internalname, StringUtil.LTrim( StringUtil.NToC( AV37TotalPaid, 18, 2, ".", "")), StringUtil.LTrim( ((edtavTotalpaid_Enabled!=0) ? context.localUtil.Format( AV37TotalPaid, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV37TotalPaid, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalpaid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotalpaid_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsowed_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsowed_Internalname, "Is Owed", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_41_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsowed_Internalname, StringUtil.BoolToStr( AV99IsOwed), "", "Is Owed", 1, chkavIsowed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(72, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,72);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRegisterorder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Register", bttRegisterorder_Jsonclick, 5, "Register Order", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'REGISTERORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelregister_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Cancel", bttCancelregister_Jsonclick, 5, "Cancel Register Order", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELREGISTER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentregister_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Code", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Product", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Curr. Stock", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Ordered", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Received", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Curr. Price", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Sugg. Price", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Subtotal", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetIsFreestyle(true);
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl101( ) ;
         }
         if ( wbEnd == 101 )
         {
            wbEnd = 0;
            nRC_GXsfl_101 = (int)(nGXsfl_101_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV124GXV13 = nGXsfl_101_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableedit_Internalname, divTableedit_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonsedit_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Confirm Changes?", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirmchanges_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Confirm", bttConfirmchanges_Jsonclick, 5, "Confirm Edit", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel1_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Cancel", bttCancel1_Jsonclick, 5, "Cancel Edit", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELEDIT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentedit_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Remove", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Code", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Product", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Curr. Stock", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Min. Stock", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Ordered", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            FgrideditContainer.SetIsFreestyle(true);
            FgrideditContainer.SetWrapped(nGXWrapped);
            StartGridControl161( ) ;
         }
         if ( wbEnd == 161 )
         {
            wbEnd = 0;
            nRC_GXsfl_161 = (int)(nGXsfl_161_idx-1);
            if ( FgrideditContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV133GXV22 = nGXsfl_161_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FgrideditContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridedit", FgrideditContainer, subFgridedit_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgrideditContainerData", FgrideditContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgrideditContainerData"+"V", FgrideditContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgrideditContainerData"+"V"+"\" value='"+FgrideditContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdddetail_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Add Detail", bttAdddetail_Jsonclick, 7, "Add Detail to Order", "", StyleString, ClassString, bttAdddetail_Visible, bttAdddetail_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e11221_client"+"'", TempTags, "", 2, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCanceladd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Cancel Add", bttCanceladd_Jsonclick, 7, "Cancel Add Detail", "", StyleString, ClassString, bttCanceladd_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e12221_client"+"'", TempTags, "", 2, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, divTable2_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Add", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Code", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Product", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Curr. Stock", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Min. Stock", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            FgridposiblenewdetailsContainer.SetIsFreestyle(true);
            FgridposiblenewdetailsContainer.SetWrapped(nGXWrapped);
            StartGridControl208( ) ;
         }
         if ( wbEnd == 208 )
         {
            wbEnd = 0;
            nRC_GXsfl_208 = (int)(nGXsfl_208_idx-1);
            if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV139GXV28 = nGXsfl_208_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FgridposiblenewdetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridposiblenewdetails", FgridposiblenewdetailsContainer, subFgridposiblenewdetails_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData", FgridposiblenewdetailsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData"+"V", FgridposiblenewdetailsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridposiblenewdetailsContainerData"+"V"+"\" value='"+FgridposiblenewdetailsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTcancel_Internalname, divTcancel_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonscancel_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Cancel Order?", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 237,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttYes_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Yes", bttYes_Jsonclick, 5, "Yes", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'YES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Right", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 239,'',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttNo_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "No", bttNo_Jsonclick, 5, "No", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPurchaseordercanceleddescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPurchaseordercanceleddescription_Internalname, "Reason", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'" + sGXsfl_41_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavPurchaseordercanceleddescription_Internalname, AV70PurchaseOrderCanceledDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,246);\"", 0, 1, edtavPurchaseordercanceleddescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontentcancel_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Code", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Product", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Curr. Stock", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Min. Stock", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Ordered", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            FgridcancelContainer.SetIsFreestyle(true);
            FgridcancelContainer.SetWrapped(nGXWrapped);
            StartGridControl263( ) ;
         }
         if ( wbEnd == 263 )
         {
            wbEnd = 0;
            nRC_GXsfl_263 = (int)(nGXsfl_263_idx-1);
            if ( FgridcancelContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV144GXV33 = nGXsfl_263_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FgridcancelContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridcancel", FgridcancelContainer, subFgridcancel_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridcancelContainerData", FgridcancelContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FgridcancelContainerData"+"V", FgridcancelContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridcancelContainerData"+"V"+"\" value='"+FgridcancelContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTpay_Internalname, divTpay_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepaybuttons_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotaltopay_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotaltopay_Internalname, "Total To Pay", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 291,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotaltopay_Internalname, StringUtil.LTrim( StringUtil.NToC( AV102TotalToPay, 18, 2, ".", "")), StringUtil.LTrim( ((edtavTotaltopay_Enabled!=0) ? context.localUtil.Format( AV102TotalToPay, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV102TotalToPay, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,291);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotaltopay_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotaltopay_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 293,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttPayorder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Pay", bttPayorder_Jsonclick, 5, "Pay", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PAYORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 295,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttPaycancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Cancel", bttPaycancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'PAYCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPManagePurchase.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepaygrid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetWrapped(nGXWrapped);
            StartGridControl303( ) ;
         }
         if ( wbEnd == 303 )
         {
            wbEnd = 0;
            nRC_GXsfl_303 = (int)(nGXsfl_303_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV150GXV39 = nGXsfl_303_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nEOF", GRIDPURCHASEORDERSFILTERED_nEOF);
                  GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
                  AV112GXV1 = nGXsfl_41_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridpurchaseordersfilteredContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpurchaseordersfiltered", GridpurchaseordersfilteredContainer, subGridpurchaseordersfiltered_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData", GridpurchaseordersfilteredContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpurchaseordersfilteredContainerData"+"V", GridpurchaseordersfilteredContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpurchaseordersfilteredContainerData"+"V"+"\" value='"+GridpurchaseordersfilteredContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 101 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV124GXV13 = nGXsfl_101_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 161 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FgrideditContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV133GXV22 = nGXsfl_161_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FgrideditContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridedit", FgrideditContainer, subFgridedit_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgrideditContainerData", FgrideditContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgrideditContainerData"+"V", FgrideditContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgrideditContainerData"+"V"+"\" value='"+FgrideditContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 208 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV139GXV28 = nGXsfl_208_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FgridposiblenewdetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridposiblenewdetails", FgridposiblenewdetailsContainer, subFgridposiblenewdetails_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData", FgridposiblenewdetailsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridposiblenewdetailsContainerData"+"V", FgridposiblenewdetailsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridposiblenewdetailsContainerData"+"V"+"\" value='"+FgridposiblenewdetailsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 263 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FgridcancelContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV144GXV33 = nGXsfl_263_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FgridcancelContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fgridcancel", FgridcancelContainer, subFgridcancel_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridcancelContainerData", FgridcancelContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FgridcancelContainerData"+"V", FgridcancelContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FgridcancelContainerData"+"V"+"\" value='"+FgridcancelContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 303 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV150GXV39 = nGXsfl_303_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START222( )
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
            Form.Meta.addItem("description", "WPManage Purchase", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP220( ) ;
      }

      protected void WS222( )
      {
         START222( ) ;
         EVT222( ) ;
      }

      protected void EVT222( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'REGISTERORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RegisterOrder' */
                              E13222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELREGISTER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelRegister' */
                              E14222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELEDIT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelEdit' */
                              E15222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELCANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelCancel' */
                              E16222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Confirm' */
                              E17222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'YES'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Yes' */
                              E18222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAYORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PayOrder' */
                              E19222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PAYCANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'PayCancel' */
                              E20222 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPURCHASEORDERSFILTEREDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPURCHASEORDERSFILTEREDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridpurchaseordersfiltered_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridpurchaseordersfiltered_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridpurchaseordersfiltered_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridpurchaseordersfiltered_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 39), "CTLQUANTITYRECEIVED.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "CTLNEWCOSTPRICE.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) )
                           {
                              nGXsfl_101_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
                              SubsflControlProps_10111( ) ;
                              AV124GXV13 = nGXsfl_101_idx;
                              if ( ( AV61DetailsRegister.Count >= AV124GXV13 ) && ( AV124GXV13 > 0 ) )
                              {
                                 AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CTLQUANTITYRECEIVED.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLNEWCOSTPRICE.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E232211 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VREMOVEDETAIL.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "FGRIDEDIT.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "FGRIDEDIT.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VREMOVEDETAIL.CLICK") == 0 ) )
                           {
                              nGXsfl_161_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
                              SubsflControlProps_16110( ) ;
                              AV133GXV22 = nGXsfl_161_idx;
                              if ( ( AV59DetailsEdit.Count >= AV133GXV22 ) && ( AV133GXV22 > 0 ) )
                              {
                                 AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22));
                                 AV62RemoveDetail = cgiGet( edtavRemovedetail_Internalname);
                                 AssignProp("", false, edtavRemovedetail_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV162Removedetail_GXI : context.convertURL( context.PathToRelativeUrl( AV62RemoveDetail))), !bGXsfl_161_Refreshing);
                                 AssignProp("", false, edtavRemovedetail_Internalname, "SrcSet", context.GetImageSrcSet( AV62RemoveDetail), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "VREMOVEDETAIL.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E24222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDEDIT.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E25222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDEDIT.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E262210 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECTTHIS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 30), "FGRIDPOSIBLENEWDETAILS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "FGRIDPOSIBLENEWDETAILS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECTTHIS.CLICK") == 0 ) )
                           {
                              nGXsfl_208_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
                              SubsflControlProps_2089( ) ;
                              AV139GXV28 = nGXsfl_208_idx;
                              if ( ( AV65PosiblesNewDetails.Count >= AV139GXV28 ) && ( AV139GXV28 > 0 ) )
                              {
                                 AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28));
                                 AV66SelectThis = cgiGet( edtavSelectthis_Internalname);
                                 AssignProp("", false, edtavSelectthis_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV163Selectthis_GXI : context.convertURL( context.PathToRelativeUrl( AV66SelectThis))), !bGXsfl_208_Refreshing);
                                 AssignProp("", false, edtavSelectthis_Internalname, "SrcSet", context.GetImageSrcSet( AV66SelectThis), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "VSELECTTHIS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E27222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDPOSIBLENEWDETAILS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E28222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FGRIDPOSIBLENEWDETAILS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E29229 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "FGRIDCANCEL.LOAD") == 0 )
                           {
                              nGXsfl_263_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
                              SubsflControlProps_2638( ) ;
                              AV144GXV33 = nGXsfl_263_idx;
                              if ( ( AV60DetailsCancel.Count >= AV144GXV33 ) && ( AV144GXV33 > 0 ) )
                              {
                                 AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FGRIDCANCEL.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E30228 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 )
                           {
                              nGXsfl_303_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
                              SubsflControlProps_3037( ) ;
                              AV150GXV39 = nGXsfl_303_idx;
                              if ( ( AV101DetailsPay.Count >= AV150GXV39 ) && ( AV150GXV39 > 0 ) )
                              {
                                 AV101DetailsPay.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E31227 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "CTLADDIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "CTLPAIDIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDELETEIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLMODIFYIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 34), "GRIDPURCHASEORDERSFILTERED.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "GRIDPURCHASEORDERSFILTERED.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "CTLADDIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDELETEIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLMODIFYIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "CTLPAIDIMAGE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) )
                           {
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
                              if ( ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) && ( AV112GXV1 > 0 ) )
                              {
                                 AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
                                 AV57Edit = cgiGet( edtavEdit_Internalname);
                                 AssignProp("", false, edtavEdit_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)) ? AV169Edit_GXI : context.convertURL( context.PathToRelativeUrl( AV57Edit))), !bGXsfl_41_Refreshing);
                                 AssignProp("", false, edtavEdit_Internalname, "SrcSet", context.GetImageSrcSet( AV57Edit), true);
                                 AV56Cancel = cgiGet( edtavCancel_Internalname);
                                 AssignProp("", false, edtavCancel_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)) ? AV168Cancel_GXI : context.convertURL( context.PathToRelativeUrl( AV56Cancel))), !bGXsfl_41_Refreshing);
                                 AssignProp("", false, edtavCancel_Internalname, "SrcSet", context.GetImageSrcSet( AV56Cancel), true);
                                 AV49Register = cgiGet( edtavRegister_Internalname);
                                 AssignProp("", false, edtavRegister_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)) ? AV170Register_GXI : context.convertURL( context.PathToRelativeUrl( AV49Register))), !bGXsfl_41_Refreshing);
                                 AssignProp("", false, edtavRegister_Internalname, "SrcSet", context.GetImageSrcSet( AV49Register), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E32222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLADDIMAGE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E33222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLPAIDIMAGE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E34222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLDELETEIMAGE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E35222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLMODIFYIMAGE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E36222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLSDTVOUCHERLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E37222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLDETAILSLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E38222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPURCHASEORDERSFILTERED.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E39222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPURCHASEORDERSFILTERED.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E40222 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE222( )
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

      protected void PA222( )
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
               GX_FocusControl = edtavPurchaseorderidaux_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSUPPLIER222( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data222( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvSUPPLIER_html222( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data222( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSupplier.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavSupplier.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSUPPLIER_data222( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00222 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00222_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00222_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGridpurchaseordersfiltered_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_412( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = ((subGridpurchaseordersfiltered_Islastpage==1)&&(nGXsfl_41_idx+1>subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridpurchaseordersfilteredContainer)) ;
         /* End function gxnrGridpurchaseordersfiltered_newrow */
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_3037( ) ;
         while ( nGXsfl_303_idx <= nRC_GXsfl_303 )
         {
            sendrow_3037( ) ;
            nGXsfl_303_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_303_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_303_idx+1);
            sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
            SubsflControlProps_3037( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxnrFgridcancel_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2638( ) ;
         while ( nGXsfl_263_idx <= nRC_GXsfl_263 )
         {
            sendrow_2638( ) ;
            nGXsfl_263_idx = ((subFgridcancel_Islastpage==1)&&(nGXsfl_263_idx+1>subFgridcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_263_idx+1);
            sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
            SubsflControlProps_2638( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FgridcancelContainer)) ;
         /* End function gxnrFgridcancel_newrow */
      }

      protected void gxnrFgridposiblenewdetails_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2089( ) ;
         while ( nGXsfl_208_idx <= nRC_GXsfl_208 )
         {
            sendrow_2089( ) ;
            nGXsfl_208_idx = ((subFgridposiblenewdetails_Islastpage==1)&&(nGXsfl_208_idx+1>subFgridposiblenewdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_208_idx+1);
            sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
            SubsflControlProps_2089( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FgridposiblenewdetailsContainer)) ;
         /* End function gxnrFgridposiblenewdetails_newrow */
      }

      protected void gxnrFgridedit_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_16110( ) ;
         while ( nGXsfl_161_idx <= nRC_GXsfl_161 )
         {
            sendrow_16110( ) ;
            nGXsfl_161_idx = ((subFgridedit_Islastpage==1)&&(nGXsfl_161_idx+1>subFgridedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_idx+1);
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
            SubsflControlProps_16110( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FgrideditContainer)) ;
         /* End function gxnrFgridedit_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_10111( ) ;
         while ( nGXsfl_101_idx <= nRC_GXsfl_101 )
         {
            sendrow_10111( ) ;
            nGXsfl_101_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_10111( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGridpurchaseordersfiltered_refresh( int subGridpurchaseordersfiltered_Rows ,
                                                             int AV69PurchaseOrderIdAux ,
                                                             int AV24Supplier ,
                                                             DateTime AV26FromDate ,
                                                             DateTime AV27ToDate ,
                                                             short AV52OrderBy ,
                                                             bool AV53Descending ,
                                                             bool AV99IsOwed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPURCHASEORDERSFILTERED_nCurrentRecord = 0;
         RF222( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridpurchaseordersfiltered_refresh */
      }

      protected void gxgrGrid1_refresh( int subGridpurchaseordersfiltered_Rows ,
                                        int AV24Supplier ,
                                        bool AV53Descending ,
                                        bool AV99IsOwed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2211( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrFgridedit_refresh( int subGridpurchaseordersfiltered_Rows ,
                                            int AV24Supplier ,
                                            bool AV53Descending ,
                                            bool AV99IsOwed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FGRIDEDIT_nCurrentRecord = 0;
         RF2210( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFgridedit_refresh */
      }

      protected void gxgrFgridposiblenewdetails_refresh( int subGridpurchaseordersfiltered_Rows ,
                                                         int AV24Supplier ,
                                                         bool AV53Descending ,
                                                         bool AV99IsOwed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FGRIDPOSIBLENEWDETAILS_nCurrentRecord = 0;
         RF229( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFgridposiblenewdetails_refresh */
      }

      protected void gxgrFgridcancel_refresh( int subGridpurchaseordersfiltered_Rows ,
                                              int AV24Supplier ,
                                              bool AV53Descending ,
                                              bool AV99IsOwed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FGRIDCANCEL_nCurrentRecord = 0;
         RF228( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFgridcancel_refresh */
      }

      protected void gxgrGrid2_refresh( int subGridpurchaseordersfiltered_Rows ,
                                        int AV24Supplier ,
                                        bool AV53Descending ,
                                        bool AV99IsOwed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF227( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html222( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV24Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24Supplier", StringUtil.LTrimStr( (decimal)(AV24Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         }
         if ( cmbavOrderby.ItemCount > 0 )
         {
            AV52OrderBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
            AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
         }
         AV53Descending = StringUtil.StrToBool( StringUtil.BoolToStr( AV53Descending));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV99IsOwed = StringUtil.StrToBool( StringUtil.BoolToStr( AV99IsOwed));
         AssignAttri("", false, "AV99IsOwed", AV99IsOwed);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF222( ) ;
         RF2211( ) ;
         RF2210( ) ;
         RF229( ) ;
         RF228( ) ;
         RF227( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlpurchaseorderid_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlcreateddate_Enabled = 0;
         AssignProp("", false, edtavCtlcreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreateddate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlpurchaseorderconfirmateddate_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderconfirmateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderconfirmateddate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlcloseddate_Enabled = 0;
         AssignProp("", false, edtavCtlcloseddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcloseddate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlcurrentstock_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlquantityordered_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlquantityreceived1_Enabled = 0;
         AssignProp("", false, edtavCtlquantityreceived1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityreceived1_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlcurrentstock1_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlminiumstock1_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlcode3_Enabled = 0;
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlcurrentstock3_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlminiumstock3_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlcurrentstock2_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlminiumstock2_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlquantityordered2_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlcode4_Enabled = 0;
         AssignProp("", false, edtavCtlcode4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode4_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlname4_Enabled = 0;
         AssignProp("", false, edtavCtlname4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname4_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlquantityordered3_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered3_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlproductcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlproductcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductcostprice_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlquantityreceived2_Enabled = 0;
         AssignProp("", false, edtavCtlquantityreceived2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityreceived2_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlnewcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlnewcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlnewcostprice1_Enabled), 5, 0), !bGXsfl_303_Refreshing);
      }

      protected void RF222( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridpurchaseordersfilteredContainer.ClearRows();
         }
         wbStart = 41;
         E39222 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         bGXsfl_41_Refreshing = true;
         GridpurchaseordersfilteredContainer.AddObjectProperty("GridName", "Gridpurchaseordersfiltered");
         GridpurchaseordersfilteredContainer.AddObjectProperty("CmpContext", "");
         GridpurchaseordersfilteredContainer.AddObjectProperty("InMasterPage", "false");
         GridpurchaseordersfilteredContainer.AddObjectProperty("Class", "PromptGrid");
         GridpurchaseordersfilteredContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridpurchaseordersfilteredContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridpurchaseordersfilteredContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Backcolorstyle), 1, 0, ".", "")));
         GridpurchaseordersfilteredContainer.PageSize = subGridpurchaseordersfiltered_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_412( ) ;
            E40222 ();
            if ( ( subGridpurchaseordersfiltered_Islastpage == 0 ) && ( GRIDPURCHASEORDERSFILTERED_nCurrentRecord > 0 ) && ( GRIDPURCHASEORDERSFILTERED_nGridOutOfScope == 0 ) && ( nGXsfl_41_idx == 1 ) )
            {
               GRIDPURCHASEORDERSFILTERED_nCurrentRecord = 0;
               GRIDPURCHASEORDERSFILTERED_nGridOutOfScope = 1;
               subgridpurchaseordersfiltered_firstpage( ) ;
               E40222 ();
            }
            wbEnd = 41;
            WB220( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes222( )
      {
      }

      protected void RF227( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 303;
         nGXsfl_303_idx = 1;
         sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
         SubsflControlProps_3037( ) ;
         bGXsfl_303_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "PromptGrid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_3037( ) ;
            E31227 ();
            wbEnd = 303;
            WB220( ) ;
         }
         bGXsfl_303_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes227( )
      {
      }

      protected void RF228( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FgridcancelContainer.ClearRows();
         }
         wbStart = 263;
         nGXsfl_263_idx = 1;
         sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
         SubsflControlProps_2638( ) ;
         bGXsfl_263_Refreshing = true;
         FgridcancelContainer.AddObjectProperty("GridName", "Fgridcancel");
         FgridcancelContainer.AddObjectProperty("CmpContext", "");
         FgridcancelContainer.AddObjectProperty("InMasterPage", "false");
         FgridcancelContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FgridcancelContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FgridcancelContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FgridcancelContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FgridcancelContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Backcolorstyle), 1, 0, ".", "")));
         FgridcancelContainer.PageSize = subFgridcancel_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_2638( ) ;
            E30228 ();
            wbEnd = 263;
            WB220( ) ;
         }
         bGXsfl_263_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes228( )
      {
      }

      protected void RF229( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FgridposiblenewdetailsContainer.ClearRows();
         }
         wbStart = 208;
         E28222 ();
         nGXsfl_208_idx = 1;
         sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
         SubsflControlProps_2089( ) ;
         bGXsfl_208_Refreshing = true;
         FgridposiblenewdetailsContainer.AddObjectProperty("GridName", "Fgridposiblenewdetails");
         FgridposiblenewdetailsContainer.AddObjectProperty("CmpContext", "");
         FgridposiblenewdetailsContainer.AddObjectProperty("InMasterPage", "false");
         FgridposiblenewdetailsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
         FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(30), 9, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Class", "PromptGrid");
         FgridposiblenewdetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Backcolorstyle), 1, 0, ".", "")));
         FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Height), 9, 0, ".", "")));
         FgridposiblenewdetailsContainer.PageSize = subFgridposiblenewdetails_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_2089( ) ;
            E29229 ();
            wbEnd = 208;
            WB220( ) ;
         }
         bGXsfl_208_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes229( )
      {
      }

      protected void RF2210( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FgrideditContainer.ClearRows();
         }
         wbStart = 161;
         E25222 ();
         nGXsfl_161_idx = 1;
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
         SubsflControlProps_16110( ) ;
         bGXsfl_161_Refreshing = true;
         FgrideditContainer.AddObjectProperty("GridName", "Fgridedit");
         FgrideditContainer.AddObjectProperty("CmpContext", "");
         FgrideditContainer.AddObjectProperty("InMasterPage", "false");
         FgrideditContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FgrideditContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FgrideditContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FgrideditContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FgrideditContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Backcolorstyle), 1, 0, ".", "")));
         FgrideditContainer.PageSize = subFgridedit_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_16110( ) ;
            E262210 ();
            wbEnd = 161;
            WB220( ) ;
         }
         bGXsfl_161_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2210( )
      {
      }

      protected void RF2211( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 101;
         nGXsfl_101_idx = 1;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_10111( ) ;
         bGXsfl_101_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_10111( ) ;
            E232211 ();
            wbEnd = 101;
            WB220( ) ;
         }
         bGXsfl_101_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2211( )
      {
      }

      protected int subGridpurchaseordersfiltered_fnc_Pagecount( )
      {
         GRIDPURCHASEORDERSFILTERED_nRecordCount = subGridpurchaseordersfiltered_fnc_Recordcount( );
         if ( ((int)((GRIDPURCHASEORDERSFILTERED_nRecordCount) % (subGridpurchaseordersfiltered_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPURCHASEORDERSFILTERED_nRecordCount/ (decimal)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPURCHASEORDERSFILTERED_nRecordCount/ (decimal)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridpurchaseordersfiltered_fnc_Recordcount( )
      {
         return AV46SDTPurchaseOrderGenerateList.Count ;
      }

      protected int subGridpurchaseordersfiltered_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subGridpurchaseordersfiltered_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage/ (decimal)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridpurchaseordersfiltered_firstpage( )
      {
         GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridpurchaseordersfiltered_nextpage( )
      {
         GRIDPURCHASEORDERSFILTERED_nRecordCount = subGridpurchaseordersfiltered_fnc_Recordcount( );
         if ( ( GRIDPURCHASEORDERSFILTERED_nRecordCount >= subGridpurchaseordersfiltered_fnc_Recordsperpage( ) ) && ( GRIDPURCHASEORDERSFILTERED_nEOF == 0 ) )
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage+subGridpurchaseordersfiltered_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         GridpurchaseordersfilteredContainer.AddObjectProperty("GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDPURCHASEORDERSFILTERED_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridpurchaseordersfiltered_previouspage( )
      {
         if ( GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage >= subGridpurchaseordersfiltered_fnc_Recordsperpage( ) )
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage-subGridpurchaseordersfiltered_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridpurchaseordersfiltered_lastpage( )
      {
         GRIDPURCHASEORDERSFILTERED_nRecordCount = subGridpurchaseordersfiltered_fnc_Recordcount( );
         if ( GRIDPURCHASEORDERSFILTERED_nRecordCount > subGridpurchaseordersfiltered_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDPURCHASEORDERSFILTERED_nRecordCount) % (subGridpurchaseordersfiltered_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nRecordCount-subGridpurchaseordersfiltered_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(GRIDPURCHASEORDERSFILTERED_nRecordCount-((int)((GRIDPURCHASEORDERSFILTERED_nRecordCount) % (subGridpurchaseordersfiltered_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridpurchaseordersfiltered_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(subGridpurchaseordersfiltered_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridcancel_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridcancel_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridcancel_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridcancel_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridposiblenewdetails_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFgridedit_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlpurchaseorderid_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlcreateddate_Enabled = 0;
         AssignProp("", false, edtavCtlcreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreateddate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlpurchaseorderconfirmateddate_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderconfirmateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderconfirmateddate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlcloseddate_Enabled = 0;
         AssignProp("", false, edtavCtlcloseddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcloseddate_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlcurrentstock_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlquantityordered_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlquantityreceived1_Enabled = 0;
         AssignProp("", false, edtavCtlquantityreceived1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityreceived1_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlcurrentstock1_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlminiumstock1_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock1_Enabled), 5, 0), !bGXsfl_161_Refreshing);
         edtavCtlcode3_Enabled = 0;
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlcurrentstock3_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlminiumstock3_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock3_Enabled), 5, 0), !bGXsfl_208_Refreshing);
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlcurrentstock2_Enabled = 0;
         AssignProp("", false, edtavCtlcurrentstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcurrentstock2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlminiumstock2_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlquantityordered2_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered2_Enabled), 5, 0), !bGXsfl_263_Refreshing);
         edtavCtlcode4_Enabled = 0;
         AssignProp("", false, edtavCtlcode4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode4_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlname4_Enabled = 0;
         AssignProp("", false, edtavCtlname4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname4_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlquantityordered3_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered3_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlproductcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlproductcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductcostprice_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlquantityreceived2_Enabled = 0;
         AssignProp("", false, edtavCtlquantityreceived2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityreceived2_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         edtavCtlnewcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlnewcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlnewcostprice1_Enabled), 5, 0), !bGXsfl_303_Refreshing);
         GXVvSUPPLIER_html222( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP220( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E32222 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Detailsregister"), AV61DetailsRegister);
            ajax_req_read_hidden_sdt(cgiGet( "Detailsedit"), AV59DetailsEdit);
            ajax_req_read_hidden_sdt(cgiGet( "Posiblesnewdetails"), AV65PosiblesNewDetails);
            ajax_req_read_hidden_sdt(cgiGet( "Detailscancel"), AV60DetailsCancel);
            ajax_req_read_hidden_sdt(cgiGet( "Detailspay"), AV101DetailsPay);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtpurchaseordergeneratelist"), AV46SDTPurchaseOrderGenerateList);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTPURCHASEORDERGENERATELIST"), AV46SDTPurchaseOrderGenerateList);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_101 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_101"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_161 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_161"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_208 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_208"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_263 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_263"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_303 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_303"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDPURCHASEORDERSFILTERED_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPURCHASEORDERSFILTERED_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridpurchaseordersfiltered_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPURCHASEORDERSFILTERED_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_41_fel_idx = 0;
            while ( nGXsfl_41_fel_idx < nRC_GXsfl_41 )
            {
               nGXsfl_41_fel_idx = ((subGridpurchaseordersfiltered_Islastpage==1)&&(nGXsfl_41_fel_idx+1>subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_fel_idx+1);
               sGXsfl_41_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_412( ) ;
               AV112GXV1 = (int)(nGXsfl_41_fel_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
               if ( ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) && ( AV112GXV1 > 0 ) )
               {
                  AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
                  AV57Edit = cgiGet( edtavEdit_Internalname);
                  AV56Cancel = cgiGet( edtavCancel_Internalname);
                  AV49Register = cgiGet( edtavRegister_Internalname);
               }
            }
            if ( nGXsfl_41_fel_idx == 0 )
            {
               nGXsfl_41_idx = 1;
               sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
               SubsflControlProps_412( ) ;
            }
            nGXsfl_41_fel_idx = 1;
            nRC_GXsfl_101 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_101"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_101_fel_idx = 0;
            while ( nGXsfl_101_fel_idx < nRC_GXsfl_101 )
            {
               nGXsfl_101_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_101_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_fel_idx+1);
               sGXsfl_101_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_10111( ) ;
               AV124GXV13 = nGXsfl_101_fel_idx;
               if ( ( AV61DetailsRegister.Count >= AV124GXV13 ) && ( AV124GXV13 > 0 ) )
               {
                  AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13));
               }
            }
            if ( nGXsfl_101_fel_idx == 0 )
            {
               nGXsfl_101_idx = 1;
               sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
               SubsflControlProps_10111( ) ;
            }
            nGXsfl_101_fel_idx = 1;
            nRC_GXsfl_161 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_161"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_161_fel_idx = 0;
            while ( nGXsfl_161_fel_idx < nRC_GXsfl_161 )
            {
               nGXsfl_161_fel_idx = ((subFgridedit_Islastpage==1)&&(nGXsfl_161_fel_idx+1>subFgridedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_fel_idx+1);
               sGXsfl_161_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_16110( ) ;
               AV133GXV22 = nGXsfl_161_fel_idx;
               if ( ( AV59DetailsEdit.Count >= AV133GXV22 ) && ( AV133GXV22 > 0 ) )
               {
                  AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22));
                  AV62RemoveDetail = cgiGet( edtavRemovedetail_Internalname);
               }
            }
            if ( nGXsfl_161_fel_idx == 0 )
            {
               nGXsfl_161_idx = 1;
               sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
               SubsflControlProps_16110( ) ;
            }
            nGXsfl_161_fel_idx = 1;
            nRC_GXsfl_208 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_208"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_208_fel_idx = 0;
            while ( nGXsfl_208_fel_idx < nRC_GXsfl_208 )
            {
               nGXsfl_208_fel_idx = ((subFgridposiblenewdetails_Islastpage==1)&&(nGXsfl_208_fel_idx+1>subFgridposiblenewdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_208_fel_idx+1);
               sGXsfl_208_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_2089( ) ;
               AV139GXV28 = nGXsfl_208_fel_idx;
               if ( ( AV65PosiblesNewDetails.Count >= AV139GXV28 ) && ( AV139GXV28 > 0 ) )
               {
                  AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28));
                  AV66SelectThis = cgiGet( edtavSelectthis_Internalname);
               }
            }
            if ( nGXsfl_208_fel_idx == 0 )
            {
               nGXsfl_208_idx = 1;
               sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
               SubsflControlProps_2089( ) ;
            }
            nGXsfl_208_fel_idx = 1;
            nRC_GXsfl_263 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_263"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_263_fel_idx = 0;
            while ( nGXsfl_263_fel_idx < nRC_GXsfl_263 )
            {
               nGXsfl_263_fel_idx = ((subFgridcancel_Islastpage==1)&&(nGXsfl_263_fel_idx+1>subFgridcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_263_fel_idx+1);
               sGXsfl_263_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_2638( ) ;
               AV144GXV33 = nGXsfl_263_fel_idx;
               if ( ( AV60DetailsCancel.Count >= AV144GXV33 ) && ( AV144GXV33 > 0 ) )
               {
                  AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33));
               }
            }
            if ( nGXsfl_263_fel_idx == 0 )
            {
               nGXsfl_263_idx = 1;
               sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
               SubsflControlProps_2638( ) ;
            }
            nGXsfl_263_fel_idx = 1;
            nRC_GXsfl_303 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_303"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_303_fel_idx = 0;
            while ( nGXsfl_303_fel_idx < nRC_GXsfl_303 )
            {
               nGXsfl_303_fel_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_303_fel_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_303_fel_idx+1);
               sGXsfl_303_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_3037( ) ;
               AV150GXV39 = nGXsfl_303_fel_idx;
               if ( ( AV101DetailsPay.Count >= AV150GXV39 ) && ( AV150GXV39 > 0 ) )
               {
                  AV101DetailsPay.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39));
               }
            }
            if ( nGXsfl_303_fel_idx == 0 )
            {
               nGXsfl_303_idx = 1;
               sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
               SubsflControlProps_3037( ) ;
            }
            nGXsfl_303_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPurchaseorderidaux_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPurchaseorderidaux_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPURCHASEORDERIDAUX");
               GX_FocusControl = edtavPurchaseorderidaux_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV69PurchaseOrderIdAux = 0;
               AssignAttri("", false, "AV69PurchaseOrderIdAux", StringUtil.LTrimStr( (decimal)(AV69PurchaseOrderIdAux), 6, 0));
            }
            else
            {
               AV69PurchaseOrderIdAux = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPurchaseorderidaux_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV69PurchaseOrderIdAux", StringUtil.LTrimStr( (decimal)(AV69PurchaseOrderIdAux), 6, 0));
            }
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV24Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24Supplier", StringUtil.LTrimStr( (decimal)(AV24Supplier), 6, 0));
            if ( context.localUtil.VCDate( cgiGet( edtavFromdate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"From Date"}), 1, "vFROMDATE");
               GX_FocusControl = edtavFromdate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26FromDate = DateTime.MinValue;
               AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
            }
            else
            {
               AV26FromDate = context.localUtil.CToD( cgiGet( edtavFromdate_Internalname), 1);
               AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTodate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"To Date"}), 1, "vTODATE");
               GX_FocusControl = edtavTodate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27ToDate = DateTime.MinValue;
               AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
            }
            else
            {
               AV27ToDate = context.localUtil.CToD( cgiGet( edtavTodate_Internalname), 1);
               AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
            }
            cmbavOrderby.Name = cmbavOrderby_Internalname;
            cmbavOrderby.CurrentValue = cgiGet( cmbavOrderby_Internalname);
            AV52OrderBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
            AV53Descending = StringUtil.StrToBool( cgiGet( chkavDescending_Internalname));
            AssignAttri("", false, "AV53Descending", AV53Descending);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalpaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalpaid_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALPAID");
               GX_FocusControl = edtavTotalpaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV37TotalPaid = 0;
               AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
            }
            else
            {
               AV37TotalPaid = context.localUtil.CToN( cgiGet( edtavTotalpaid_Internalname), ".", ",");
               AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
            }
            AV99IsOwed = StringUtil.StrToBool( cgiGet( chkavIsowed_Internalname));
            AssignAttri("", false, "AV99IsOwed", AV99IsOwed);
            AV70PurchaseOrderCanceledDescription = cgiGet( edtavPurchaseordercanceleddescription_Internalname);
            AssignAttri("", false, "AV70PurchaseOrderCanceledDescription", AV70PurchaseOrderCanceledDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotaltopay_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotaltopay_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALTOPAY");
               GX_FocusControl = edtavTotaltopay_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV102TotalToPay = 0;
               AssignAttri("", false, "AV102TotalToPay", StringUtil.LTrimStr( AV102TotalToPay, 18, 2));
            }
            else
            {
               AV102TotalToPay = context.localUtil.CToN( cgiGet( edtavTotaltopay_Internalname), ".", ",");
               AssignAttri("", false, "AV102TotalToPay", StringUtil.LTrimStr( AV102TotalToPay, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E13222( )
      {
         AV124GXV13 = nGXsfl_101_idx;
         if ( ( AV124GXV13 > 0 ) && ( AV61DetailsRegister.Count >= AV124GXV13 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13));
         }
         /* 'RegisterOrder' Routine */
         returnInSub = false;
         AV54AllOk = true;
         AssignAttri("", false, "AV54AllOk", AV54AllOk);
         /* Execute user subroutine: 'CONTROLREGISTER' */
         S112 ();
         if (returnInSub) return;
         if ( AV54AllOk )
         {
            GXt_boolean1 = AV54AllOk;
            new purchaseorderregister(context ).execute(  AV55PurchaseOrderId, ref  AV37TotalPaid, ref  AV61DetailsRegister, ref  AV99IsOwed, out  GXt_boolean1) ;
            gx_BV101 = true;
            AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
            AssignAttri("", false, "AV99IsOwed", AV99IsOwed);
            AV54AllOk = GXt_boolean1;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
            if ( AV54AllOk )
            {
               gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
               divTableregister_Visible = 0;
               AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
               AV37TotalPaid = 0;
               AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
               AV12Order.Load(0);
               AV61DetailsRegister.Clear();
               gx_BV101 = true;
               GX_msglist.addItem("Purchase Register successfull!");
               /* Execute user subroutine: 'SENDREGISTERNOTIFICATION' */
               S122 ();
               if (returnInSub) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_101_bak_idx = nGXsfl_101_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_101_idx = nGXsfl_101_bak_idx;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_10111( ) ;
      }

      protected void E14222( )
      {
         /* 'CancelRegister' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
         AV12Order.Load(0);
         AV61DetailsRegister.Clear();
         gx_BV101 = true;
         divTableregister_Visible = 0;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV101 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
            nGXsfl_101_bak_idx = nGXsfl_101_idx;
            gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_101_idx = nGXsfl_101_bak_idx;
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_10111( ) ;
         }
      }

      protected void E15222( )
      {
         /* 'CancelEdit' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
         AV12Order.Load(0);
         AV59DetailsEdit.Clear();
         gx_BV161 = true;
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV161 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
            nGXsfl_161_bak_idx = nGXsfl_161_idx;
            gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_161_idx = nGXsfl_161_bak_idx;
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
            SubsflControlProps_16110( ) ;
         }
      }

      protected void E16222( )
      {
         /* 'CancelCancel' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
         AV12Order.Load(0);
         AV60DetailsCancel.Clear();
         gx_BV263 = true;
         divTcancel_Visible = 0;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV263 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60DetailsCancel", AV60DetailsCancel);
            nGXsfl_263_bak_idx = nGXsfl_263_idx;
            gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_263_idx = nGXsfl_263_bak_idx;
            sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
            SubsflControlProps_2638( ) ;
         }
      }

      protected void E17222( )
      {
         AV133GXV22 = nGXsfl_161_idx;
         if ( ( AV133GXV22 > 0 ) && ( AV59DetailsEdit.Count >= AV133GXV22 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22));
         }
         /* 'Confirm' Routine */
         returnInSub = false;
         AV54AllOk = true;
         AssignAttri("", false, "AV54AllOk", AV54AllOk);
         /* Execute user subroutine: 'CONTROLEDIT' */
         S132 ();
         if (returnInSub) return;
         if ( AV54AllOk )
         {
            GXt_boolean1 = AV54AllOk;
            new purchaseordermodify(context ).execute(  AV55PurchaseOrderId, ref  AV59DetailsEdit, out  GXt_boolean1) ;
            gx_BV161 = true;
            AV54AllOk = GXt_boolean1;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
            if ( AV54AllOk )
            {
               divTableedit_Visible = 0;
               AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
               /* Execute user subroutine: 'SENDMODIFYNOTIFICATION' */
               S142 ();
               if (returnInSub) return;
               GX_msglist.addItem("Purchase Order Update Successfully");
               gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
            }
            else
            {
               GX_msglist.addItem("Purchase Order Update Failed");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
         nGXsfl_161_bak_idx = nGXsfl_161_idx;
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_161_idx = nGXsfl_161_bak_idx;
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
         SubsflControlProps_16110( ) ;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E32222 ();
         if (returnInSub) return;
      }

      protected void E32222( )
      {
         /* Start Routine */
         returnInSub = false;
         new getcontext(context ).execute( out  AV67Context, ref  AV54AllOk) ;
         AssignAttri("", false, "AV54AllOk", AV54AllOk);
         divTableregister_Visible = 0;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         divTcancel_Visible = 0;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         divTpay_Visible = 0;
         AssignProp("", false, divTpay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTpay_Visible), 5, 0), true);
         if ( ! AV54AllOk )
         {
            AV68WebSession.Set("SecLogIn", "Error");
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         bttRegisterorder_Jsonclick = "confirm('Are you sure to register the order?')";
         AssignProp("", false, bttRegisterorder_Internalname, "Jsonclick", bttRegisterorder_Jsonclick, true);
         bttConfirmchanges_Jsonclick = "confirm('Are you sure to confirm changes at the order?')";
         AssignProp("", false, bttConfirmchanges_Internalname, "Jsonclick", bttConfirmchanges_Jsonclick, true);
         bttYes_Jsonclick = "confirm('Are you sure to cancel the order?')";
         AssignProp("", false, bttYes_Internalname, "Jsonclick", bttYes_Jsonclick, true);
         bttPayorder_Jsonclick = "confirm('Are you sure to confirm Pay?')";
         AssignProp("", false, bttPayorder_Internalname, "Jsonclick", bttPayorder_Jsonclick, true);
         AV99IsOwed = true;
         AssignAttri("", false, "AV99IsOwed", AV99IsOwed);
      }

      protected void E33222( )
      {
         AV124GXV13 = nGXsfl_101_idx;
         if ( ( AV124GXV13 > 0 ) && ( AV61DetailsRegister.Count >= AV124GXV13 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13));
         }
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* Ctladdimage_Click Routine */
         returnInSub = false;
         if ( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Canadd )
         {
            AV37TotalPaid = 0;
            AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
            AV61DetailsRegister.Clear();
            gx_BV101 = true;
            AV55PurchaseOrderId = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid;
            AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
            GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2 = AV61DetailsRegister;
            new purchaseordercargedetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2) ;
            AV61DetailsRegister = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2;
            gx_BV101 = true;
            /* Execute user subroutine: 'HIDETABLES' */
            S152 ();
            if (returnInSub) return;
            divTableregister_Visible = 1;
            AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
            /* Execute user subroutine: 'CALCULATETOTAL' */
            S162 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_101_bak_idx = nGXsfl_101_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_101_idx = nGXsfl_101_bak_idx;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_10111( ) ;
      }

      protected void E34222( )
      {
         AV150GXV39 = nGXsfl_303_idx;
         if ( ( AV150GXV39 > 0 ) && ( AV101DetailsPay.Count >= AV150GXV39 ) )
         {
            AV101DetailsPay.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39));
         }
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* Ctlpaidimage_Click Routine */
         returnInSub = false;
         if ( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Canpay )
         {
            AV102TotalToPay = 0;
            AssignAttri("", false, "AV102TotalToPay", StringUtil.LTrimStr( AV102TotalToPay, 18, 2));
            AV101DetailsPay.Clear();
            gx_BV303 = true;
            AV55PurchaseOrderId = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid;
            AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
            GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2 = AV101DetailsPay;
            new purchaseordercargedetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2) ;
            AV101DetailsPay = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2;
            gx_BV303 = true;
            AV157GXV46 = 1;
            while ( AV157GXV46 <= AV101DetailsPay.Count )
            {
               AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV157GXV46));
               AV102TotalToPay = (decimal)(AV102TotalToPay+(AV40OneDetail.gxTpr_Quantityreceived*AV40OneDetail.gxTpr_Newcostprice));
               AssignAttri("", false, "AV102TotalToPay", StringUtil.LTrimStr( AV102TotalToPay, 18, 2));
               AV157GXV46 = (int)(AV157GXV46+1);
            }
            /* Execute user subroutine: 'HIDETABLES' */
            S152 ();
            if (returnInSub) return;
            divTpay_Visible = 1;
            AssignProp("", false, divTpay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTpay_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         if ( gx_BV303 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV101DetailsPay", AV101DetailsPay);
            nGXsfl_303_bak_idx = nGXsfl_303_idx;
            gxgrGrid2_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_303_idx = nGXsfl_303_bak_idx;
            sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
            SubsflControlProps_3037( ) ;
         }
      }

      protected void E35222( )
      {
         AV144GXV33 = nGXsfl_263_idx;
         if ( ( AV144GXV33 > 0 ) && ( AV60DetailsCancel.Count >= AV144GXV33 ) )
         {
            AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33));
         }
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* Ctldeleteimage_Click Routine */
         returnInSub = false;
         if ( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Candelete )
         {
            AV55PurchaseOrderId = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid;
            AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
            GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2 = AV60DetailsCancel;
            new purchaseordercargedetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2) ;
            AV60DetailsCancel = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2;
            gx_BV263 = true;
            /* Execute user subroutine: 'HIDETABLES' */
            S152 ();
            if (returnInSub) return;
            divTcancel_Visible = 1;
            AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         if ( gx_BV263 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60DetailsCancel", AV60DetailsCancel);
            nGXsfl_263_bak_idx = nGXsfl_263_idx;
            gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_263_idx = nGXsfl_263_bak_idx;
            sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
            SubsflControlProps_2638( ) ;
         }
      }

      protected void E36222( )
      {
         AV139GXV28 = nGXsfl_208_idx;
         if ( ( AV139GXV28 > 0 ) && ( AV65PosiblesNewDetails.Count >= AV139GXV28 ) )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28));
         }
         AV133GXV22 = nGXsfl_161_idx;
         if ( ( AV133GXV22 > 0 ) && ( AV59DetailsEdit.Count >= AV133GXV22 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22));
         }
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* Ctlmodifyimage_Click Routine */
         returnInSub = false;
         if ( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Canmodify )
         {
            AV55PurchaseOrderId = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid;
            AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
            GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2 = AV59DetailsEdit;
            new purchaseordercargedetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2) ;
            AV59DetailsEdit = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2;
            gx_BV161 = true;
            GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2 = AV65PosiblesNewDetails;
            new purchaseordercargeposiblenewdetails(context ).execute(  AV55PurchaseOrderId, out  GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2) ;
            AV65PosiblesNewDetails = GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2;
            gx_BV208 = true;
            AV12Order = new SdtPurchaseOrder(context);
            AV12Order.Load(AV55PurchaseOrderId);
            /* Execute user subroutine: 'HIDETABLES' */
            S152 ();
            if (returnInSub) return;
            divTableedit_Visible = 1;
            AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
            divTable2_Visible = 0;
            AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
            if ( AV65PosiblesNewDetails.Count <= 0 )
            {
               bttAdddetail_Enabled = 0;
               AssignProp("", false, bttAdddetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttAdddetail_Enabled), 5, 0), true);
            }
            bttAdddetail_Visible = 1;
            AssignProp("", false, bttAdddetail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdddetail_Visible), 5, 0), true);
            bttCanceladd_Visible = 0;
            AssignProp("", false, bttCanceladd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCanceladd_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         if ( gx_BV161 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
            nGXsfl_161_bak_idx = nGXsfl_161_idx;
            gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_161_idx = nGXsfl_161_bak_idx;
            sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
            SubsflControlProps_16110( ) ;
         }
         if ( gx_BV208 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65PosiblesNewDetails", AV65PosiblesNewDetails);
            nGXsfl_208_bak_idx = nGXsfl_208_idx;
            gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_208_idx = nGXsfl_208_bak_idx;
            sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
            SubsflControlProps_2089( ) ;
         }
      }

      protected void E37222( )
      {
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* Ctlsdtvoucherlink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV48window.Url = formatLink("apurchaseordervoucher.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV48window.SetReturnParms(new Object[] {});
         AV48window.Height = 370;
         AV48window.Width = 500;
         context.NewWindow(AV48window);
         /*  Sending Event outputs  */
      }

      protected void E38222( )
      {
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* Ctldetailslink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV48window.Url = formatLink("wppurchaseorderdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV46SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV48window.SetReturnParms(new Object[] {});
         AV48window.Height = 370;
         AV48window.Width = 500;
         context.NewWindow(AV48window);
         /*  Sending Event outputs  */
      }

      protected void E21222( )
      {
         AV124GXV13 = nGXsfl_101_idx;
         if ( ( AV124GXV13 > 0 ) && ( AV61DetailsRegister.Count >= AV124GXV13 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13));
         }
         /* Ctlquantityreceived_Controlvaluechanged Routine */
         returnInSub = false;
         AV40OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem));
         AV40OneDetail.gxTpr_Subtotal = (decimal)(AV40OneDetail.gxTpr_Newcostprice*AV40OneDetail.gxTpr_Quantityreceived);
         GXt_decimal3 = 0;
         new roundvalue(context ).execute(  AV40OneDetail.gxTpr_Subtotal, out  GXt_decimal3) ;
         ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem)).gxTpr_Subtotal = GXt_decimal3;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_101_bak_idx = nGXsfl_101_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_101_idx = nGXsfl_101_bak_idx;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_10111( ) ;
      }

      protected void E22222( )
      {
         AV124GXV13 = nGXsfl_101_idx;
         if ( ( AV124GXV13 > 0 ) && ( AV61DetailsRegister.Count >= AV124GXV13 ) )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13));
         }
         /* Ctlnewcostprice_Controlvaluechanged Routine */
         returnInSub = false;
         AV40OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem));
         AV40OneDetail.gxTpr_Subtotal = (decimal)(AV40OneDetail.gxTpr_Newcostprice*AV40OneDetail.gxTpr_Quantityreceived);
         GXt_decimal3 = 0;
         new roundvalue(context ).execute(  AV40OneDetail.gxTpr_Subtotal, out  GXt_decimal3) ;
         ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV61DetailsRegister.CurrentItem)).gxTpr_Subtotal = GXt_decimal3;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61DetailsRegister", AV61DetailsRegister);
         nGXsfl_101_bak_idx = nGXsfl_101_idx;
         gxgrGrid1_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_101_idx = nGXsfl_101_bak_idx;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_10111( ) ;
      }

      protected void S162( )
      {
         /* 'CALCULATETOTAL' Routine */
         returnInSub = false;
         AV37TotalPaid = 0;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
         AV158GXV47 = 1;
         while ( AV158GXV47 <= AV61DetailsRegister.Count )
         {
            AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV158GXV47));
            AV37TotalPaid = (decimal)(AV37TotalPaid+(AV40OneDetail.gxTpr_Subtotal));
            AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
            AV158GXV47 = (int)(AV158GXV47+1);
         }
         GXt_decimal3 = AV37TotalPaid;
         new roundvalue(context ).execute(  AV37TotalPaid, out  GXt_decimal3) ;
         AV37TotalPaid = GXt_decimal3;
         AssignAttri("", false, "AV37TotalPaid", StringUtil.LTrimStr( AV37TotalPaid, 18, 2));
      }

      protected void S112( )
      {
         /* 'CONTROLREGISTER' Routine */
         returnInSub = false;
         AV54AllOk = true;
         AssignAttri("", false, "AV54AllOk", AV54AllOk);
         AV159GXV48 = 1;
         while ( AV159GXV48 <= AV61DetailsRegister.Count )
         {
            AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV159GXV48));
            if ( ( AV40OneDetail.gxTpr_Subtotal < Convert.ToDecimal( 0 )) )
            {
               GX_msglist.addItem("Some Subtotal is invalid!");
               AV54AllOk = false;
               AssignAttri("", false, "AV54AllOk", AV54AllOk);
               if (true) break;
            }
            if ( AV40OneDetail.gxTpr_Quantityreceived < 0 )
            {
               GX_msglist.addItem("Some Quantity Received is invalid!");
               AV54AllOk = false;
               AssignAttri("", false, "AV54AllOk", AV54AllOk);
               if (true) break;
            }
            AV159GXV48 = (int)(AV159GXV48+1);
         }
         if ( AV61DetailsRegister.Count <= 0 )
         {
            GX_msglist.addItem("Choose a Purchase Order First!");
            AV54AllOk = false;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
         if ( ( AV37TotalPaid < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Total Paid is invalid!");
            AV54AllOk = false;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
         if ( AV54AllOk )
         {
            AV109Count = 0;
            AV160GXV49 = 1;
            while ( AV160GXV49 <= AV61DetailsRegister.Count )
            {
               AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV160GXV49));
               if ( AV40OneDetail.gxTpr_Quantityreceived > 0 )
               {
                  if (true) break;
               }
               else
               {
                  AV109Count = (short)(AV109Count+1);
               }
               AV160GXV49 = (int)(AV160GXV49+1);
            }
            if ( AV109Count == AV61DetailsRegister.Count )
            {
               AV54AllOk = false;
               AssignAttri("", false, "AV54AllOk", AV54AllOk);
               GX_msglist.addItem("Register Fail!, at least one product must be received");
            }
         }
      }

      protected void E18222( )
      {
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* 'Yes' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONTROLCANCEL' */
         S172 ();
         if (returnInSub) return;
         if ( AV71ControlPassed )
         {
            AV12Order = new SdtPurchaseOrder(context);
            AV12Order.Load(AV55PurchaseOrderId);
            AV12Order.gxTpr_Purchaseorderactive = false;
            AV12Order.gxTpr_Purchaseordercanceleddescription = AV70PurchaseOrderCanceledDescription;
            AV12Order.Update();
            if ( AV12Order.Success() )
            {
               AV12Order.Load(0);
               AV60DetailsCancel.Clear();
               gx_BV263 = true;
               divTcancel_Visible = 0;
               AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
               GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4 = AV46SDTPurchaseOrderGenerateList;
               new purchaseordergetfiltered(context ).execute(  AV69PurchaseOrderIdAux,  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4) ;
               AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
               AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
               AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
               AssignAttri("", false, "AV53Descending", AV53Descending);
               AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4;
               gx_BV41 = true;
               gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
               GX_msglist.addItem("Purchase Order Canceled Succefully");
               context.CommitDataStores("wpmanagepurchase",pr_default);
               /* Execute user subroutine: 'SENDCANCELNOTIFICATION' */
               S182 ();
               if (returnInSub) return;
            }
            else
            {
               GX_msglist.addItem("Purchase Order has not been Cancel"+AV12Order.GetMessages().ToJSonString(false));
               context.RollbackDataStores("wpmanagepurchase",pr_default);
            }
         }
         /*  Sending Event outputs  */
         if ( gx_BV263 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV60DetailsCancel", AV60DetailsCancel);
            nGXsfl_263_bak_idx = nGXsfl_263_idx;
            gxgrFgridcancel_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_263_idx = nGXsfl_263_bak_idx;
            sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
            SubsflControlProps_2638( ) ;
         }
         if ( gx_BV41 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
            nGXsfl_41_bak_idx = nGXsfl_41_idx;
            gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
            nGXsfl_41_idx = nGXsfl_41_bak_idx;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void S132( )
      {
         /* 'CONTROLEDIT' Routine */
         returnInSub = false;
         if ( AV59DetailsEdit.Count <= 0 )
         {
            AV54AllOk = false;
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
            GX_msglist.addItem("The Purchase Order must have at least one product");
         }
         if ( AV54AllOk )
         {
            AV161GXV50 = 1;
            while ( AV161GXV50 <= AV59DetailsEdit.Count )
            {
               AV40OneDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV161GXV50));
               if ( AV40OneDetail.gxTpr_Quantityordered <= 0 )
               {
                  GX_msglist.addItem("Some Quatity is invalid!");
                  AV54AllOk = false;
                  AssignAttri("", false, "AV54AllOk", AV54AllOk);
                  if (true) break;
               }
               AV161GXV50 = (int)(AV161GXV50+1);
            }
         }
      }

      protected void E27222( )
      {
         AV139GXV28 = nGXsfl_208_idx;
         if ( ( AV139GXV28 > 0 ) && ( AV65PosiblesNewDetails.Count >= AV139GXV28 ) )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28));
         }
         AV133GXV22 = nGXsfl_161_idx;
         if ( ( AV133GXV22 > 0 ) && ( AV59DetailsEdit.Count >= AV133GXV22 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22));
         }
         /* Selectthis_Click Routine */
         returnInSub = false;
         AV59DetailsEdit.Add(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV65PosiblesNewDetails.CurrentItem)), 0);
         gx_BV161 = true;
         AV65PosiblesNewDetails.RemoveItem(AV65PosiblesNewDetails.IndexOf(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV65PosiblesNewDetails.CurrentItem))));
         gx_BV208 = true;
         divTable2_Visible = 0;
         AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
         if ( AV65PosiblesNewDetails.Count <= 0 )
         {
            bttAdddetail_Enabled = 0;
            AssignProp("", false, bttAdddetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttAdddetail_Enabled), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
         nGXsfl_161_bak_idx = nGXsfl_161_idx;
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_161_idx = nGXsfl_161_bak_idx;
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
         SubsflControlProps_16110( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65PosiblesNewDetails", AV65PosiblesNewDetails);
         nGXsfl_208_bak_idx = nGXsfl_208_idx;
         gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_208_idx = nGXsfl_208_bak_idx;
         sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
         SubsflControlProps_2089( ) ;
      }

      protected void E24222( )
      {
         AV139GXV28 = nGXsfl_208_idx;
         if ( ( AV139GXV28 > 0 ) && ( AV65PosiblesNewDetails.Count >= AV139GXV28 ) )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28));
         }
         AV133GXV22 = nGXsfl_161_idx;
         if ( ( AV133GXV22 > 0 ) && ( AV59DetailsEdit.Count >= AV133GXV22 ) )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22));
         }
         /* Removedetail_Click Routine */
         returnInSub = false;
         AV65PosiblesNewDetails.Add((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV59DetailsEdit.CurrentItem)).Clone()), 0);
         gx_BV208 = true;
         AV59DetailsEdit.RemoveItem(AV59DetailsEdit.IndexOf(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)(AV59DetailsEdit.CurrentItem))));
         gx_BV161 = true;
         if ( AV65PosiblesNewDetails.Count > 0 )
         {
            bttAdddetail_Enabled = 1;
            AssignProp("", false, bttAdddetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttAdddetail_Enabled), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65PosiblesNewDetails", AV65PosiblesNewDetails);
         nGXsfl_208_bak_idx = nGXsfl_208_idx;
         gxgrFgridposiblenewdetails_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_208_idx = nGXsfl_208_bak_idx;
         sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
         SubsflControlProps_2089( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV59DetailsEdit", AV59DetailsEdit);
         nGXsfl_161_bak_idx = nGXsfl_161_idx;
         gxgrFgridedit_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
         nGXsfl_161_idx = nGXsfl_161_bak_idx;
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
         SubsflControlProps_16110( ) ;
      }

      protected void E25222( )
      {
         /* Fgridedit_Refresh Routine */
         returnInSub = false;
         edtavRemovedetail_gximage = "GeneXusUnanimo_delete_light";
         AssignProp("", false, edtavRemovedetail_Internalname, "gximage", edtavRemovedetail_gximage, !bGXsfl_161_Refreshing);
         AV62RemoveDetail = context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( ));
         AssignProp("", false, edtavRemovedetail_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV162Removedetail_GXI : context.convertURL( context.PathToRelativeUrl( AV62RemoveDetail))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavRemovedetail_Internalname, "SrcSet", context.GetImageSrcSet( AV62RemoveDetail), true);
         AV162Removedetail_GXI = GXDbFile.PathToUrl( context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( )));
         AssignProp("", false, edtavRemovedetail_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV162Removedetail_GXI : context.convertURL( context.PathToRelativeUrl( AV62RemoveDetail))), !bGXsfl_161_Refreshing);
         AssignProp("", false, edtavRemovedetail_Internalname, "SrcSet", context.GetImageSrcSet( AV62RemoveDetail), true);
         /*  Sending Event outputs  */
      }

      protected void E28222( )
      {
         /* Fgridposiblenewdetails_Refresh Routine */
         returnInSub = false;
         edtavSelectthis_gximage = "GeneXusUnanimo_featured_green";
         AssignProp("", false, edtavSelectthis_Internalname, "gximage", edtavSelectthis_gximage, !bGXsfl_208_Refreshing);
         AV66SelectThis = context.GetImagePath( "af7f81cc-394c-4184-95e4-f6c46e6a69de", "", context.GetTheme( ));
         AssignProp("", false, edtavSelectthis_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV163Selectthis_GXI : context.convertURL( context.PathToRelativeUrl( AV66SelectThis))), !bGXsfl_208_Refreshing);
         AssignProp("", false, edtavSelectthis_Internalname, "SrcSet", context.GetImageSrcSet( AV66SelectThis), true);
         AV163Selectthis_GXI = GXDbFile.PathToUrl( context.GetImagePath( "af7f81cc-394c-4184-95e4-f6c46e6a69de", "", context.GetTheme( )));
         AssignProp("", false, edtavSelectthis_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV163Selectthis_GXI : context.convertURL( context.PathToRelativeUrl( AV66SelectThis))), !bGXsfl_208_Refreshing);
         AssignProp("", false, edtavSelectthis_Internalname, "SrcSet", context.GetImageSrcSet( AV66SelectThis), true);
         /*  Sending Event outputs  */
      }

      protected void E39222( )
      {
         AV112GXV1 = (int)(nGXsfl_41_idx+GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage);
         if ( ( AV112GXV1 > 0 ) && ( AV46SDTPurchaseOrderGenerateList.Count >= AV112GXV1 ) )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
         }
         /* Gridpurchaseordersfiltered_Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4 = AV46SDTPurchaseOrderGenerateList;
         new purchaseordergetfiltered(context ).execute(  AV69PurchaseOrderIdAux,  AV24Supplier, ref  AV26FromDate, ref  AV27ToDate, ref  AV52OrderBy, ref  AV53Descending, out  GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4) ;
         AssignAttri("", false, "AV26FromDate", context.localUtil.Format(AV26FromDate, "99/99/99"));
         AssignAttri("", false, "AV27ToDate", context.localUtil.Format(AV27ToDate, "99/99/99"));
         AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         AV46SDTPurchaseOrderGenerateList = GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4;
         gx_BV41 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46SDTPurchaseOrderGenerateList", AV46SDTPurchaseOrderGenerateList);
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'CONTROLCANCEL' Routine */
         returnInSub = false;
         AV71ControlPassed = true;
         AssignAttri("", false, "AV71ControlPassed", AV71ControlPassed);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70PurchaseOrderCanceledDescription)) )
         {
            AV71ControlPassed = false;
            AssignAttri("", false, "AV71ControlPassed", AV71ControlPassed);
            GX_msglist.addItem("Reason is required to Cancel");
         }
      }

      protected void S122( )
      {
         /* 'SENDREGISTERNOTIFICATION' Routine */
         returnInSub = false;
         AV79HasEmail = false;
         /* Using cursor H00223 */
         pr_default.execute(1, new Object[] {AV55PurchaseOrderId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A4SupplierId = H00223_A4SupplierId[0];
            A50PurchaseOrderId = H00223_A50PurchaseOrderId[0];
            A8SupplierEmail = H00223_A8SupplierEmail[0];
            n8SupplierEmail = H00223_n8SupplierEmail[0];
            A5SupplierName = H00223_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = H00223_A52PurchaseOrderCreatedDate[0];
            A78PurchaseOrderTotalPaid = H00223_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = H00223_n78PurchaseOrderTotalPaid[0];
            A8SupplierEmail = H00223_A8SupplierEmail[0];
            n8SupplierEmail = H00223_n8SupplierEmail[0];
            A5SupplierName = H00223_A5SupplierName[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) )
            {
               AV79HasEmail = true;
               AV86EmailSupplierName = A5SupplierName;
               AV91EmailSupplierEmail = A8SupplierEmail;
               AssignAttri("", false, "AV91EmailSupplierEmail", AV91EmailSupplierEmail);
               AV87EmailCreatedDate = A52PurchaseOrderCreatedDate;
               AssignAttri("", false, "AV87EmailCreatedDate", context.localUtil.Format(AV87EmailCreatedDate, "99/99/99"));
               AV88EmailTotalPaid = A78PurchaseOrderTotalPaid;
               AssignAttri("", false, "AV88EmailTotalPaid", StringUtil.LTrimStr( AV88EmailTotalPaid, 18, 2));
               AV90EmailPurchaseOrderId = A50PurchaseOrderId;
               AssignAttri("", false, "AV90EmailPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV90EmailPurchaseOrderId), 6, 0));
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV79HasEmail )
         {
            AV74EmailTitle = "Order Registered";
            AV75EmailSubtitle = "An Order was Registered";
            /* Execute user subroutine: 'PREPAREREGISTERNOTIFICATION' */
            S212 ();
            if (returnInSub) return;
            AV72URLs.Clear();
            AV72URLs.Add(formatLink("apurchaseordervoucher.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV90EmailPurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
            AV73NamesOfAttachs.Clear();
            AV73NamesOfAttachs.Add("Voucher_"+StringUtil.Str( (decimal)(AV90EmailPurchaseOrderId), 6, 0)+".pdf", 0);
            new sendemailprepareheader(context ).execute(  AV74EmailTitle,  AV75EmailSubtitle,  AV76EmailBody, out  AV77EmailBodyAux) ;
            AV76EmailBody = AV77EmailBodyAux;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            GXt_char5 = "Order Registered";
            new sendemail(context ).execute(  AV91EmailSupplierEmail, ref  AV76EmailBody, ref  GXt_char5, ref  AV72URLs, ref  AV73NamesOfAttachs, ref  AV54AllOk) ;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
      }

      protected void S212( )
      {
         /* 'PREPAREREGISTERNOTIFICATION' Routine */
         returnInSub = false;
         AV74EmailTitle = "Order Registered";
         AV75EmailSubtitle = "An Order was registered";
         AV89EmailRegisteredDate = DateTimeUtil.ServerDate( context, pr_default);
         AV76EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Nro Order</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>" + StringUtil.Str( (decimal)(AV90EmailPurchaseOrderId), 6, 0) + "</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV87EmailCreatedDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Confirmated Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV89EmailRegisteredDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Total Paid</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV88EmailTotalPaid, "ZZZZZZZZZZZZZZ9.99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                </table>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
      }

      protected void S142( )
      {
         /* 'SENDMODIFYNOTIFICATION' Routine */
         returnInSub = false;
         AV79HasEmail = false;
         /* Using cursor H00224 */
         pr_default.execute(2, new Object[] {AV55PurchaseOrderId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A4SupplierId = H00224_A4SupplierId[0];
            A50PurchaseOrderId = H00224_A50PurchaseOrderId[0];
            A8SupplierEmail = H00224_A8SupplierEmail[0];
            n8SupplierEmail = H00224_n8SupplierEmail[0];
            A5SupplierName = H00224_A5SupplierName[0];
            A8SupplierEmail = H00224_A8SupplierEmail[0];
            n8SupplierEmail = H00224_n8SupplierEmail[0];
            A5SupplierName = H00224_A5SupplierName[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) )
            {
               AV79HasEmail = true;
               AV86EmailSupplierName = A5SupplierName;
               AV91EmailSupplierEmail = A8SupplierEmail;
               AssignAttri("", false, "AV91EmailSupplierEmail", AV91EmailSupplierEmail);
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( AV79HasEmail )
         {
            AV74EmailTitle = "Order Modified";
            AV75EmailSubtitle = "An Order was Modified";
            /* Execute user subroutine: 'PREPAREMODIFYNOTIFICATION' */
            S222 ();
            if (returnInSub) return;
            AV72URLs.Clear();
            AV72URLs.Add(formatLink("apurchaseordervoucher.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV55PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
            AV73NamesOfAttachs.Clear();
            AV73NamesOfAttachs.Add("Voucher_"+StringUtil.Str( (decimal)(AV55PurchaseOrderId), 6, 0)+".pdf", 0);
            new sendemailprepareheader(context ).execute(  AV74EmailTitle,  AV75EmailSubtitle,  AV76EmailBody, out  AV77EmailBodyAux) ;
            AV76EmailBody = AV77EmailBodyAux;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            GXt_char5 = "Order Modified";
            new sendemail(context ).execute(  AV91EmailSupplierEmail, ref  AV76EmailBody, ref  GXt_char5, ref  AV72URLs, ref  AV73NamesOfAttachs, ref  AV54AllOk) ;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
      }

      protected void S222( )
      {
         /* 'PREPAREMODIFYNOTIFICATION' Routine */
         returnInSub = false;
         AV74EmailTitle = "Order Modified";
         AV75EmailSubtitle = "An Order has been Modified";
         AV93EmailModifiedDate = DateTimeUtil.ServerDate( context, pr_default);
         AV76EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Nro Order</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>" + StringUtil.Str( (decimal)(AV90EmailPurchaseOrderId), 6, 0) + "</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV87EmailCreatedDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Modified Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV93EmailModifiedDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                </table>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
      }

      protected void S182( )
      {
         /* 'SENDCANCELNOTIFICATION' Routine */
         returnInSub = false;
         AV79HasEmail = false;
         /* Using cursor H00225 */
         pr_default.execute(3, new Object[] {AV55PurchaseOrderId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A4SupplierId = H00225_A4SupplierId[0];
            A50PurchaseOrderId = H00225_A50PurchaseOrderId[0];
            A8SupplierEmail = H00225_A8SupplierEmail[0];
            n8SupplierEmail = H00225_n8SupplierEmail[0];
            A5SupplierName = H00225_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = H00225_A52PurchaseOrderCreatedDate[0];
            A8SupplierEmail = H00225_A8SupplierEmail[0];
            n8SupplierEmail = H00225_n8SupplierEmail[0];
            A5SupplierName = H00225_A5SupplierName[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) )
            {
               AV79HasEmail = true;
               AV86EmailSupplierName = A5SupplierName;
               AV91EmailSupplierEmail = A8SupplierEmail;
               AssignAttri("", false, "AV91EmailSupplierEmail", AV91EmailSupplierEmail);
               AV90EmailPurchaseOrderId = A50PurchaseOrderId;
               AssignAttri("", false, "AV90EmailPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV90EmailPurchaseOrderId), 6, 0));
               AV87EmailCreatedDate = A52PurchaseOrderCreatedDate;
               AssignAttri("", false, "AV87EmailCreatedDate", context.localUtil.Format(AV87EmailCreatedDate, "99/99/99"));
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( AV79HasEmail )
         {
            AV74EmailTitle = "Order Canceled";
            AV75EmailSubtitle = "An Order was Canceled";
            /* Execute user subroutine: 'PREPARECANCELNOTIFICATION' */
            S232 ();
            if (returnInSub) return;
            AV72URLs.Clear();
            AV72URLs.Add(formatLink("apurchaseordervoucher.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV55PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
            AV73NamesOfAttachs.Clear();
            AV73NamesOfAttachs.Add("Voucher_"+StringUtil.Str( (decimal)(AV55PurchaseOrderId), 6, 0)+".pdf", 0);
            new sendemailprepareheader(context ).execute(  AV74EmailTitle,  AV75EmailSubtitle,  AV76EmailBody, out  AV77EmailBodyAux) ;
            AV76EmailBody = AV77EmailBodyAux;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            GXt_char5 = "Order Canceled";
            new sendemail(context ).execute(  AV91EmailSupplierEmail, ref  AV76EmailBody, ref  GXt_char5, ref  AV72URLs, ref  AV73NamesOfAttachs, ref  AV54AllOk) ;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
      }

      protected void S232( )
      {
         /* 'PREPARECANCELNOTIFICATION' Routine */
         returnInSub = false;
         AV74EmailTitle = "Order Canceled";
         AV75EmailSubtitle = "An order has been canceled";
         AV94EmailCanceledDate = DateTimeUtil.ServerDate( context, pr_default);
         AV76EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Nro Order</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>" + StringUtil.Str( (decimal)(AV90EmailPurchaseOrderId), 6, 0) + "</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV87EmailCreatedDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Canceled Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV94EmailCanceledDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                </table>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
      }

      protected void S152( )
      {
         /* 'HIDETABLES' Routine */
         returnInSub = false;
         divTableregister_Visible = 0;
         AssignProp("", false, divTableregister_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableregister_Visible), 5, 0), true);
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         divTcancel_Visible = 0;
         AssignProp("", false, divTcancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTcancel_Visible), 5, 0), true);
         divTpay_Visible = 0;
         AssignProp("", false, divTpay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTpay_Visible), 5, 0), true);
      }

      protected void S192( )
      {
         /* 'CONTROLTOTALTOPAY' Routine */
         returnInSub = false;
         AV71ControlPassed = true;
         AssignAttri("", false, "AV71ControlPassed", AV71ControlPassed);
         if ( ( AV102TotalToPay < Convert.ToDecimal( 0 )) )
         {
            AV71ControlPassed = false;
            AssignAttri("", false, "AV71ControlPassed", AV71ControlPassed);
            GX_msglist.addItem("Total to pay must be higher that zero");
         }
      }

      protected void E19222( )
      {
         /* 'PayOrder' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONTROLTOTALTOPAY' */
         S192 ();
         if (returnInSub) return;
         if ( AV71ControlPassed )
         {
            AV103PurchaseOrder.Load(AV55PurchaseOrderId);
            AV103PurchaseOrder.gxTpr_Purchaseordertotalpaid = AV102TotalToPay;
            AV103PurchaseOrder.gxTpr_Purchaseorderwaspaid = true;
            AV103PurchaseOrder.gxTpr_Purchaseorderpaiddate = DateTimeUtil.ServerDate( context, pr_default);
            AV103PurchaseOrder.Update();
            if ( AV103PurchaseOrder.Success() )
            {
               AV90EmailPurchaseOrderId = AV55PurchaseOrderId;
               AssignAttri("", false, "AV90EmailPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV90EmailPurchaseOrderId), 6, 0));
               AV87EmailCreatedDate = AV103PurchaseOrder.gxTpr_Purchaseordercreateddate;
               AssignAttri("", false, "AV87EmailCreatedDate", context.localUtil.Format(AV87EmailCreatedDate, "99/99/99"));
               AV88EmailTotalPaid = AV103PurchaseOrder.gxTpr_Purchaseordertotalpaid;
               AssignAttri("", false, "AV88EmailTotalPaid", StringUtil.LTrimStr( AV88EmailTotalPaid, 18, 2));
               context.CommitDataStores("wpmanagepurchase",pr_default);
               /* Execute user subroutine: 'SENDPAYNOTIFICATION' */
               S202 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'HIDETABLES' */
               S152 ();
               if (returnInSub) return;
               GX_msglist.addItem("Purchase Order Paid Successfully");
               AV102TotalToPay = 0;
               AssignAttri("", false, "AV102TotalToPay", StringUtil.LTrimStr( AV102TotalToPay, 18, 2));
               AV101DetailsPay.Clear();
               gx_BV303 = true;
               AV55PurchaseOrderId = 0;
               AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
               gxgrGridpurchaseordersfiltered_refresh( subGridpurchaseordersfiltered_Rows, AV69PurchaseOrderIdAux, AV24Supplier, AV26FromDate, AV27ToDate, AV52OrderBy, AV53Descending, AV99IsOwed) ;
            }
            else
            {
               context.RollbackDataStores("wpmanagepurchase",pr_default);
               GX_msglist.addItem("Pay Order Failed: "+AV103PurchaseOrder.GetMessages().ToJSonString(false));
            }
         }
         /*  Sending Event outputs  */
         if ( gx_BV303 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV101DetailsPay", AV101DetailsPay);
            nGXsfl_303_bak_idx = nGXsfl_303_idx;
            gxgrGrid2_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_303_idx = nGXsfl_303_bak_idx;
            sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
            SubsflControlProps_3037( ) ;
         }
      }

      protected void E20222( )
      {
         /* 'PayCancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'HIDETABLES' */
         S152 ();
         if (returnInSub) return;
         AV102TotalToPay = 0;
         AssignAttri("", false, "AV102TotalToPay", StringUtil.LTrimStr( AV102TotalToPay, 18, 2));
         AV101DetailsPay.Clear();
         gx_BV303 = true;
         AV55PurchaseOrderId = 0;
         AssignAttri("", false, "AV55PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV55PurchaseOrderId), 6, 0));
         /* Execute user subroutine: 'HIDETABLES' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV303 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV101DetailsPay", AV101DetailsPay);
            nGXsfl_303_bak_idx = nGXsfl_303_idx;
            gxgrGrid2_refresh( subGridpurchaseordersfiltered_Rows, AV24Supplier, AV53Descending, AV99IsOwed) ;
            nGXsfl_303_idx = nGXsfl_303_bak_idx;
            sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
            SubsflControlProps_3037( ) ;
         }
      }

      protected void S202( )
      {
         /* 'SENDPAYNOTIFICATION' Routine */
         returnInSub = false;
         AV79HasEmail = false;
         /* Using cursor H00226 */
         pr_default.execute(4, new Object[] {AV55PurchaseOrderId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A4SupplierId = H00226_A4SupplierId[0];
            A50PurchaseOrderId = H00226_A50PurchaseOrderId[0];
            A8SupplierEmail = H00226_A8SupplierEmail[0];
            n8SupplierEmail = H00226_n8SupplierEmail[0];
            A5SupplierName = H00226_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = H00226_A52PurchaseOrderCreatedDate[0];
            A8SupplierEmail = H00226_A8SupplierEmail[0];
            n8SupplierEmail = H00226_n8SupplierEmail[0];
            A5SupplierName = H00226_A5SupplierName[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) )
            {
               AV79HasEmail = true;
               AV86EmailSupplierName = A5SupplierName;
               AV91EmailSupplierEmail = A8SupplierEmail;
               AssignAttri("", false, "AV91EmailSupplierEmail", AV91EmailSupplierEmail);
               AV90EmailPurchaseOrderId = A50PurchaseOrderId;
               AssignAttri("", false, "AV90EmailPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV90EmailPurchaseOrderId), 6, 0));
               AV87EmailCreatedDate = A52PurchaseOrderCreatedDate;
               AssignAttri("", false, "AV87EmailCreatedDate", context.localUtil.Format(AV87EmailCreatedDate, "99/99/99"));
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         if ( AV79HasEmail )
         {
            AV74EmailTitle = "Order Paid";
            AV75EmailSubtitle = "An Order was Paid";
            /* Execute user subroutine: 'PREPAREPAYNOTIFICATION' */
            S242 ();
            if (returnInSub) return;
            AV72URLs.Clear();
            AV72URLs.Add(formatLink("apurchaseordervoucher.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV55PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
            AV73NamesOfAttachs.Clear();
            AV73NamesOfAttachs.Add("Voucher_"+StringUtil.Str( (decimal)(AV55PurchaseOrderId), 6, 0)+".pdf", 0);
            new sendemailprepareheader(context ).execute(  AV74EmailTitle,  AV75EmailSubtitle,  AV76EmailBody, out  AV77EmailBodyAux) ;
            AV76EmailBody = AV77EmailBodyAux;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            GXt_char5 = "Order Paid";
            new sendemail(context ).execute(  AV91EmailSupplierEmail, ref  AV76EmailBody, ref  GXt_char5, ref  AV72URLs, ref  AV73NamesOfAttachs, ref  AV54AllOk) ;
            AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
            AssignAttri("", false, "AV54AllOk", AV54AllOk);
         }
      }

      protected void S242( )
      {
         /* 'PREPAREPAYNOTIFICATION' Routine */
         returnInSub = false;
         AV74EmailTitle = "Order Paid";
         AV75EmailSubtitle = "An Order was Paid";
         AV105EmailPaidDate = DateTimeUtil.ServerDate( context, pr_default);
         AV76EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Nro Order</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>" + StringUtil.Str( (decimal)(AV90EmailPurchaseOrderId), 6, 0) + "</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV87EmailCreatedDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Paid Date</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV105EmailPaidDate, "99/99/99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    <tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td style=\"text-align:left;\"><strong>Total Paid</strong></td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                        <td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += context.localUtil.Format( AV88EmailTotalPaid, "ZZZZZZZZZZZZZZ9.99");
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "					</td>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                    </tr>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
         AV76EmailBody += "                </table>";
         AssignAttri("", false, "AV76EmailBody", AV76EmailBody);
      }

      private void E40222( )
      {
         /* Gridpurchaseordersfiltered_Load Routine */
         returnInSub = false;
         AV112GXV1 = 1;
         while ( AV112GXV1 <= AV46SDTPurchaseOrderGenerateList.Count )
         {
            AV46SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 41;
            }
            if ( ( subGridpurchaseordersfiltered_Islastpage == 1 ) || ( 5 == 0 ) || ( ( GRIDPURCHASEORDERSFILTERED_nCurrentRecord >= GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage ) && ( GRIDPURCHASEORDERSFILTERED_nCurrentRecord < GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage + subGridpurchaseordersfiltered_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_412( ) ;
            }
            GRIDPURCHASEORDERSFILTERED_nEOF = (short)(((GRIDPURCHASEORDERSFILTERED_nCurrentRecord<GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage+subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDPURCHASEORDERSFILTERED_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDPURCHASEORDERSFILTERED_nEOF), 1, 0, ".", "")));
            GRIDPURCHASEORDERSFILTERED_nCurrentRecord = (long)(GRIDPURCHASEORDERSFILTERED_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
            {
               DoAjaxLoad(41, GridpurchaseordersfilteredRow);
            }
            AV112GXV1 = (int)(AV112GXV1+1);
         }
      }

      private void E31227( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         AV150GXV39 = 1;
         while ( AV150GXV39 <= AV101DetailsPay.Count )
         {
            AV101DetailsPay.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 303;
            }
            sendrow_3037( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_303_Refreshing )
            {
               DoAjaxLoad(303, Grid2Row);
            }
            AV150GXV39 = (int)(AV150GXV39+1);
         }
      }

      private void E30228( )
      {
         /* Fgridcancel_Load Routine */
         returnInSub = false;
         AV144GXV33 = 1;
         while ( AV144GXV33 <= AV60DetailsCancel.Count )
         {
            AV60DetailsCancel.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 263;
            }
            sendrow_2638( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_263_Refreshing )
            {
               DoAjaxLoad(263, FgridcancelRow);
            }
            AV144GXV33 = (int)(AV144GXV33+1);
         }
      }

      private void E29229( )
      {
         /* Fgridposiblenewdetails_Load Routine */
         returnInSub = false;
         AV139GXV28 = 1;
         while ( AV139GXV28 <= AV65PosiblesNewDetails.Count )
         {
            AV65PosiblesNewDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 208;
            }
            sendrow_2089( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_208_Refreshing )
            {
               DoAjaxLoad(208, FgridposiblenewdetailsRow);
            }
            AV139GXV28 = (int)(AV139GXV28+1);
         }
      }

      private void E262210( )
      {
         /* Fgridedit_Load Routine */
         returnInSub = false;
         AV133GXV22 = 1;
         while ( AV133GXV22 <= AV59DetailsEdit.Count )
         {
            AV59DetailsEdit.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 161;
            }
            sendrow_16110( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_161_Refreshing )
            {
               DoAjaxLoad(161, FgrideditRow);
            }
            AV133GXV22 = (int)(AV133GXV22+1);
         }
      }

      private void E232211( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV124GXV13 = 1;
         while ( AV124GXV13 <= AV61DetailsRegister.Count )
         {
            AV61DetailsRegister.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 101;
            }
            sendrow_10111( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_101_Refreshing )
            {
               DoAjaxLoad(101, Grid1Row);
            }
            AV124GXV13 = (int)(AV124GXV13+1);
         }
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
         PA222( ) ;
         WS222( ) ;
         WE222( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241218234960", true, true);
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
         context.AddJavascriptSource("wpmanagepurchase.js", "?20241218234961", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_412( )
      {
         edtavEdit_Internalname = "vEDIT_"+sGXsfl_41_idx;
         edtavCancel_Internalname = "vCANCEL_"+sGXsfl_41_idx;
         edtavRegister_Internalname = "vREGISTER_"+sGXsfl_41_idx;
         edtavCtladdimage_Internalname = "CTLADDIMAGE_"+sGXsfl_41_idx;
         edtavCtldeleteimage_Internalname = "CTLDELETEIMAGE_"+sGXsfl_41_idx;
         edtavCtlmodifyimage_Internalname = "CTLMODIFYIMAGE_"+sGXsfl_41_idx;
         edtavCtlpaidimage_Internalname = "CTLPAIDIMAGE_"+sGXsfl_41_idx;
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID_"+sGXsfl_41_idx;
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE_"+sGXsfl_41_idx;
         edtavCtlpurchaseorderconfirmateddate_Internalname = "CTLPURCHASEORDERCONFIRMATEDDATE_"+sGXsfl_41_idx;
         edtavCtlcloseddate_Internalname = "CTLCLOSEDDATE_"+sGXsfl_41_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_41_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_41_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtavEdit_Internalname = "vEDIT_"+sGXsfl_41_fel_idx;
         edtavCancel_Internalname = "vCANCEL_"+sGXsfl_41_fel_idx;
         edtavRegister_Internalname = "vREGISTER_"+sGXsfl_41_fel_idx;
         edtavCtladdimage_Internalname = "CTLADDIMAGE_"+sGXsfl_41_fel_idx;
         edtavCtldeleteimage_Internalname = "CTLDELETEIMAGE_"+sGXsfl_41_fel_idx;
         edtavCtlmodifyimage_Internalname = "CTLMODIFYIMAGE_"+sGXsfl_41_fel_idx;
         edtavCtlpaidimage_Internalname = "CTLPAIDIMAGE_"+sGXsfl_41_fel_idx;
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID_"+sGXsfl_41_fel_idx;
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE_"+sGXsfl_41_fel_idx;
         edtavCtlpurchaseorderconfirmateddate_Internalname = "CTLPURCHASEORDERCONFIRMATEDDATE_"+sGXsfl_41_fel_idx;
         edtavCtlcloseddate_Internalname = "CTLCLOSEDDATE_"+sGXsfl_41_fel_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_41_fel_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_41_fel_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         SubsflControlProps_412( ) ;
         WB220( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_41_idx <= subGridpurchaseordersfiltered_fnc_Recordsperpage( ) * 1 ) )
         {
            GridpurchaseordersfilteredRow = GXWebRow.GetNew(context,GridpurchaseordersfilteredContainer);
            if ( subGridpurchaseordersfiltered_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Odd";
               }
            }
            else if ( subGridpurchaseordersfiltered_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 0;
               subGridpurchaseordersfiltered_Backcolor = subGridpurchaseordersfiltered_Allbackcolor;
               if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Uniform";
               }
            }
            else if ( subGridpurchaseordersfiltered_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Odd";
               }
               subGridpurchaseordersfiltered_Backcolor = (int)(0x0);
            }
            else if ( subGridpurchaseordersfiltered_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridpurchaseordersfiltered_Backstyle = 1;
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
               {
                  subGridpurchaseordersfiltered_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Even";
                  }
               }
               else
               {
                  subGridpurchaseordersfiltered_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridpurchaseordersfiltered_Class, "") != 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Odd";
                  }
               }
            }
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavEdit_gximage, "")==0) ? "" : "GX_Image_"+edtavEdit_gximage+"_Class");
            StyleString = "";
            AV57Edit_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit))&&String.IsNullOrEmpty(StringUtil.RTrim( AV169Edit_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV57Edit)) ? AV169Edit_GXI : context.PathToRelativeUrl( AV57Edit));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEdit_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)0,(short)0,(string)"Edit Order",(string)"Edit Order",(short)0,(short)1,(short)25,(string)"px",(short)25,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV57Edit_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCancel_gximage, "")==0) ? "" : "GX_Image_"+edtavCancel_gximage+"_Class");
            StyleString = "";
            AV56Cancel_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel))&&String.IsNullOrEmpty(StringUtil.RTrim( AV168Cancel_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV56Cancel)) ? AV168Cancel_GXI : context.PathToRelativeUrl( AV56Cancel));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCancel_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)0,(short)0,(string)"Cancel Order",(string)"Cancel Order",(short)0,(short)1,(short)25,(string)"px",(short)25,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV56Cancel_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRegister_gximage, "")==0) ? "" : "GX_Image_"+edtavRegister_gximage+"_Class");
            StyleString = "";
            AV49Register_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV49Register))&&String.IsNullOrEmpty(StringUtil.RTrim( AV170Register_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV49Register)) ? AV170Register_GXI : context.PathToRelativeUrl( AV49Register));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRegister_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)0,(short)0,(string)"Register Order",(string)"Register Order",(short)0,(short)1,(short)25,(string)"px",(short)25,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV49Register_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCtladdimage_Enabled!=0)&&(edtavCtladdimage_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 45,'',false,'',41)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCtladdimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtladdimage_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Addimage)) ? ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Addimage_gxi : context.PathToRelativeUrl( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Addimage));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtladdimage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Register Order",(string)"Register Order",(short)0,(short)1,(short)24,(string)"px",(short)24,(string)"px",(short)0,(short)0,(short)5,(string)edtavCtladdimage_Jsonclick,"'"+""+"'"+",false,"+"'"+"ECTLADDIMAGE.CLICK."+sGXsfl_41_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCtldeleteimage_Enabled!=0)&&(edtavCtldeleteimage_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 46,'',false,'',41)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCtldeleteimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtldeleteimage_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Deleteimage)) ? ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Deleteimage_gxi : context.PathToRelativeUrl( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Deleteimage));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtldeleteimage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Cancel Order",(string)"Cancel Order",(short)0,(short)1,(short)24,(string)"px",(short)24,(string)"px",(short)0,(short)0,(short)5,(string)edtavCtldeleteimage_Jsonclick,"'"+""+"'"+",false,"+"'"+"ECTLDELETEIMAGE.CLICK."+sGXsfl_41_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCtlmodifyimage_Enabled!=0)&&(edtavCtlmodifyimage_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 47,'',false,'',41)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCtlmodifyimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtlmodifyimage_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Modifyimage)) ? ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Modifyimage_gxi : context.PathToRelativeUrl( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Modifyimage));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlmodifyimage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Edit Order",(string)"Edit Order",(short)0,(short)1,(short)24,(string)"px",(short)24,(string)"px",(short)0,(short)0,(short)5,(string)edtavCtlmodifyimage_Jsonclick,"'"+""+"'"+",false,"+"'"+"ECTLMODIFYIMAGE.CLICK."+sGXsfl_41_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCtlpaidimage_Enabled!=0)&&(edtavCtlpaidimage_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 48,'',false,'',41)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCtlpaidimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtlpaidimage_gximage+"_Class");
            StyleString = "";
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Paidimage)) ? ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Paidimage_gxi : context.PathToRelativeUrl( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Paidimage));
            GridpurchaseordersfilteredRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpaidimage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Pay Order",(string)"Pay Order",(short)0,(short)1,(short)24,(string)"px",(short)24,(string)"px",(short)0,(short)0,(short)5,(string)edtavCtlpaidimage_Jsonclick,"'"+""+"'"+",false,"+"'"+"ECTLPAIDIMAGE.CLICK."+sGXsfl_41_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpurchaseorderid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Purchaseorderid), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlpurchaseorderid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Purchaseorderid), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Purchaseorderid), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpurchaseorderid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpurchaseorderid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcreateddate_Internalname,context.localUtil.Format(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Createddate, "99/99/99"),context.localUtil.Format( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Createddate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcreateddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcreateddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpurchaseorderconfirmateddate_Internalname,context.localUtil.Format(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Purchaseorderconfirmateddate, "99/99/99"),context.localUtil.Format( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Purchaseorderconfirmateddate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpurchaseorderconfirmateddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpurchaseorderconfirmateddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcloseddate_Internalname,context.localUtil.Format(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Closeddate, "99/99/99"),context.localUtil.Format( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Closeddate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcloseddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcloseddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsuppliername_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Suppliername,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsuppliername_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsuppliername_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtldetailslink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Detailslink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLDETAILSLINK.CLICK."+sGXsfl_41_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtldetailslink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtldetailslink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridpurchaseordersfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsdtvoucherlink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV46SDTPurchaseOrderGenerateList.Item(AV112GXV1)).gxTpr_Sdtvoucherlink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLSDTVOUCHERLINK.CLICK."+sGXsfl_41_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsdtvoucherlink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsdtvoucherlink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes222( ) ;
            GridpurchaseordersfilteredContainer.AddRow(GridpurchaseordersfilteredRow);
            nGXsfl_41_idx = ((subGridpurchaseordersfiltered_Islastpage==1)&&(nGXsfl_41_idx+1>subGridpurchaseordersfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void SubsflControlProps_10111( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_101_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_101_idx;
         edtavCtlcurrentstock_Internalname = "CTLCURRENTSTOCK_"+sGXsfl_101_idx;
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED_"+sGXsfl_101_idx;
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED_"+sGXsfl_101_idx;
         edtavCtlquantityreceived1_Internalname = "CTLQUANTITYRECEIVED1_"+sGXsfl_101_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_101_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_101_idx;
      }

      protected void SubsflControlProps_fel_10111( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_101_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_101_fel_idx;
         edtavCtlcurrentstock_Internalname = "CTLCURRENTSTOCK_"+sGXsfl_101_fel_idx;
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED_"+sGXsfl_101_fel_idx;
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED_"+sGXsfl_101_fel_idx;
         edtavCtlquantityreceived1_Internalname = "CTLQUANTITYRECEIVED1_"+sGXsfl_101_fel_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_101_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_101_fel_idx;
      }

      protected void sendrow_10111( )
      {
         SubsflControlProps_10111( ) ;
         WB220( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_101_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_101_idx+"\">") ;
         }
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_101_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered_Internalname,(string)"Quantity Ordered",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantityordered_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Quantityordered), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Quantityordered), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlquantityordered_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived_Internalname,(string)"Quantity Received",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantityreceived_Enabled!=0)&&(edtavCtlquantityreceived_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 118,'',false,'"+sGXsfl_101_idx+"',101)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Quantityreceived), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Quantityreceived), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantityreceived_Enabled!=0)&&(edtavCtlquantityreceived_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,118);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityreceived_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived1_Internalname,(string)"Product Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Productcostprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlquantityreceived1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Productcostprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Productcostprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityreceived1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlquantityreceived1_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,(string)"New Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 124,'',false,'"+sGXsfl_101_idx+"',101)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Newcostprice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Newcostprice, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,124);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,(string)"Subtotal",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV61DetailsRegister.Item(AV124GXV13)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2211( ) ;
         /* End of Columns property logic. */
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_101_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_10111( ) ;
         /* End function sendrow_10111 */
      }

      protected void SubsflControlProps_16110( )
      {
         edtavRemovedetail_Internalname = "vREMOVEDETAIL_"+sGXsfl_161_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_161_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_161_idx;
         edtavCtlcurrentstock1_Internalname = "CTLCURRENTSTOCK1_"+sGXsfl_161_idx;
         edtavCtlminiumstock1_Internalname = "CTLMINIUMSTOCK1_"+sGXsfl_161_idx;
         edtavCtlquantityordered1_Internalname = "CTLQUANTITYORDERED1_"+sGXsfl_161_idx;
      }

      protected void SubsflControlProps_fel_16110( )
      {
         edtavRemovedetail_Internalname = "vREMOVEDETAIL_"+sGXsfl_161_fel_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_161_fel_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_161_fel_idx;
         edtavCtlcurrentstock1_Internalname = "CTLCURRENTSTOCK1_"+sGXsfl_161_fel_idx;
         edtavCtlminiumstock1_Internalname = "CTLMINIUMSTOCK1_"+sGXsfl_161_fel_idx;
         edtavCtlquantityordered1_Internalname = "CTLQUANTITYORDERED1_"+sGXsfl_161_fel_idx;
      }

      protected void sendrow_16110( )
      {
         SubsflControlProps_16110( ) ;
         WB220( ) ;
         FgrideditRow = GXWebRow.GetNew(context,FgrideditContainer);
         if ( subFgridedit_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFgridedit_Backstyle = 0;
            if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
            {
               subFgridedit_Linesclass = subFgridedit_Class+"Odd";
            }
         }
         else if ( subFgridedit_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFgridedit_Backstyle = 0;
            subFgridedit_Backcolor = subFgridedit_Allbackcolor;
            if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
            {
               subFgridedit_Linesclass = subFgridedit_Class+"Uniform";
            }
         }
         else if ( subFgridedit_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFgridedit_Backstyle = 1;
            if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
            {
               subFgridedit_Linesclass = subFgridedit_Class+"Odd";
            }
            subFgridedit_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFgridedit_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFgridedit_Backstyle = 1;
            if ( ((int)((nGXsfl_161_idx) % (2))) == 0 )
            {
               subFgridedit_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
               {
                  subFgridedit_Linesclass = subFgridedit_Class+"Even";
               }
            }
            else
            {
               subFgridedit_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFgridedit_Class, "") != 0 )
               {
                  subFgridedit_Linesclass = subFgridedit_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FgrideditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFgridedit_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_161_idx+"\">") ;
         }
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table1_Internalname+"_"+sGXsfl_161_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavRemovedetail_Internalname+"\"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavRemovedetail_Enabled!=0)&&(edtavRemovedetail_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 167,'',false,'',161)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRemovedetail_gximage, "")==0) ? "" : "GX_Image_"+edtavRemovedetail_gximage+"_Class");
         StyleString = "";
         AV62RemoveDetail_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail))&&String.IsNullOrEmpty(StringUtil.RTrim( AV162Removedetail_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV62RemoveDetail)) ? AV162Removedetail_GXI : context.PathToRelativeUrl( AV62RemoveDetail));
         FgrideditRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRemovedetail_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavRemovedetail_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVREMOVEDETAIL.CLICK."+sGXsfl_161_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV62RemoveDetail_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode1_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock1_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock1_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock1_Internalname,(string)"Minium Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlminiumstock1_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgrideditRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgrideditRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered1_Internalname,(string)"Quantity Ordered",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantityordered1_Enabled!=0)&&(edtavCtlquantityordered1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 182,'',false,'"+sGXsfl_161_idx+"',161)\"" : " ");
         ROClassString = "Attribute";
         FgrideditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV59DetailsEdit.Item(AV133GXV22)).gxTpr_Quantityordered), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantityordered1_Enabled!=0)&&(edtavCtlquantityordered1_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,182);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)161,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgrideditRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2210( ) ;
         /* End of Columns property logic. */
         FgrideditContainer.AddRow(FgrideditRow);
         nGXsfl_161_idx = ((subFgridedit_Islastpage==1)&&(nGXsfl_161_idx+1>subFgridedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_161_idx+1);
         sGXsfl_161_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_161_idx), 4, 0), 4, "0");
         SubsflControlProps_16110( ) ;
         /* End function sendrow_16110 */
      }

      protected void SubsflControlProps_2089( )
      {
         edtavSelectthis_Internalname = "vSELECTTHIS_"+sGXsfl_208_idx;
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_208_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_208_idx;
         edtavCtlcurrentstock3_Internalname = "CTLCURRENTSTOCK3_"+sGXsfl_208_idx;
         edtavCtlminiumstock3_Internalname = "CTLMINIUMSTOCK3_"+sGXsfl_208_idx;
      }

      protected void SubsflControlProps_fel_2089( )
      {
         edtavSelectthis_Internalname = "vSELECTTHIS_"+sGXsfl_208_fel_idx;
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_208_fel_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_208_fel_idx;
         edtavCtlcurrentstock3_Internalname = "CTLCURRENTSTOCK3_"+sGXsfl_208_fel_idx;
         edtavCtlminiumstock3_Internalname = "CTLMINIUMSTOCK3_"+sGXsfl_208_fel_idx;
      }

      protected void sendrow_2089( )
      {
         SubsflControlProps_2089( ) ;
         WB220( ) ;
         FgridposiblenewdetailsRow = GXWebRow.GetNew(context,FgridposiblenewdetailsContainer);
         if ( subFgridposiblenewdetails_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 0;
            if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
            {
               subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Odd";
            }
         }
         else if ( subFgridposiblenewdetails_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 0;
            subFgridposiblenewdetails_Backcolor = subFgridposiblenewdetails_Allbackcolor;
            if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
            {
               subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Uniform";
            }
         }
         else if ( subFgridposiblenewdetails_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 1;
            if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
            {
               subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Odd";
            }
            subFgridposiblenewdetails_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFgridposiblenewdetails_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFgridposiblenewdetails_Backstyle = 1;
            if ( ((int)((nGXsfl_208_idx) % (2))) == 0 )
            {
               subFgridposiblenewdetails_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
               {
                  subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Even";
               }
            }
            else
            {
               subFgridposiblenewdetails_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFgridposiblenewdetails_Class, "") != 0 )
               {
                  subFgridposiblenewdetails_Linesclass = subFgridposiblenewdetails_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFgridposiblenewdetails_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_208_idx+"\">") ;
         }
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid2table_Internalname+"_"+sGXsfl_208_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Select This",(string)"col-sm-3 ImageLabel",(short)0,(bool)true,(string)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavSelectthis_Enabled!=0)&&(edtavSelectthis_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 213,'',false,'',208)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavSelectthis_gximage, "")==0) ? "" : "GX_Image_"+edtavSelectthis_gximage+"_Class");
         StyleString = "";
         AV66SelectThis_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis))&&String.IsNullOrEmpty(StringUtil.RTrim( AV163Selectthis_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV66SelectThis)) ? AV163Selectthis_GXI : context.PathToRelativeUrl( AV66SelectThis));
         FgridposiblenewdetailsRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelectthis_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavSelectthis_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVSELECTTHIS.CLICK."+sGXsfl_208_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV66SelectThis_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode3_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)208,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname3_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)208,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock3_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock3_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock3_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock3_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)208,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridposiblenewdetailsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridposiblenewdetailsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock3_Internalname,(string)"Minium Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridposiblenewdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock3_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock3_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV65PosiblesNewDetails.Item(AV139GXV28)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlminiumstock3_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)208,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridposiblenewdetailsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes229( ) ;
         /* End of Columns property logic. */
         FgridposiblenewdetailsContainer.AddRow(FgridposiblenewdetailsRow);
         nGXsfl_208_idx = ((subFgridposiblenewdetails_Islastpage==1)&&(nGXsfl_208_idx+1>subFgridposiblenewdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_208_idx+1);
         sGXsfl_208_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_208_idx), 4, 0), 4, "0");
         SubsflControlProps_2089( ) ;
         /* End function sendrow_2089 */
      }

      protected void SubsflControlProps_2638( )
      {
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_263_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_263_idx;
         edtavCtlcurrentstock2_Internalname = "CTLCURRENTSTOCK2_"+sGXsfl_263_idx;
         edtavCtlminiumstock2_Internalname = "CTLMINIUMSTOCK2_"+sGXsfl_263_idx;
         edtavCtlquantityordered2_Internalname = "CTLQUANTITYORDERED2_"+sGXsfl_263_idx;
      }

      protected void SubsflControlProps_fel_2638( )
      {
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_263_fel_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_263_fel_idx;
         edtavCtlcurrentstock2_Internalname = "CTLCURRENTSTOCK2_"+sGXsfl_263_fel_idx;
         edtavCtlminiumstock2_Internalname = "CTLMINIUMSTOCK2_"+sGXsfl_263_fel_idx;
         edtavCtlquantityordered2_Internalname = "CTLQUANTITYORDERED2_"+sGXsfl_263_fel_idx;
      }

      protected void sendrow_2638( )
      {
         SubsflControlProps_2638( ) ;
         WB220( ) ;
         FgridcancelRow = GXWebRow.GetNew(context,FgridcancelContainer);
         if ( subFgridcancel_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFgridcancel_Backstyle = 0;
            if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
            {
               subFgridcancel_Linesclass = subFgridcancel_Class+"Odd";
            }
         }
         else if ( subFgridcancel_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFgridcancel_Backstyle = 0;
            subFgridcancel_Backcolor = subFgridcancel_Allbackcolor;
            if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
            {
               subFgridcancel_Linesclass = subFgridcancel_Class+"Uniform";
            }
         }
         else if ( subFgridcancel_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFgridcancel_Backstyle = 1;
            if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
            {
               subFgridcancel_Linesclass = subFgridcancel_Class+"Odd";
            }
            subFgridcancel_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFgridcancel_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFgridcancel_Backstyle = 1;
            if ( ((int)((nGXsfl_263_idx) % (2))) == 0 )
            {
               subFgridcancel_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
               {
                  subFgridcancel_Linesclass = subFgridcancel_Class+"Even";
               }
            }
            else
            {
               subFgridcancel_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFgridcancel_Class, "") != 0 )
               {
                  subFgridcancel_Linesclass = subFgridcancel_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FgridcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFgridcancel_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_263_idx+"\">") ;
         }
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table2_Internalname+"_"+sGXsfl_263_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode2_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)263,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)263,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock2_Internalname,(string)"Current Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcurrentstock2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Currentstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlcurrentstock2_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Currentstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Currentstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcurrentstock2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcurrentstock2_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)263,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock2_Internalname,(string)"Minium Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock2_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlminiumstock2_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)263,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         FgridcancelRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         FgridcancelRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered2_Internalname,(string)"Quantity Ordered",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         FgridcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantityordered2_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Quantityordered), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV60DetailsCancel.Item(AV144GXV33)).gxTpr_Quantityordered), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlquantityordered2_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)263,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FgridcancelRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes228( ) ;
         /* End of Columns property logic. */
         FgridcancelContainer.AddRow(FgridcancelRow);
         nGXsfl_263_idx = ((subFgridcancel_Islastpage==1)&&(nGXsfl_263_idx+1>subFgridcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_263_idx+1);
         sGXsfl_263_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_263_idx), 4, 0), 4, "0");
         SubsflControlProps_2638( ) ;
         /* End function sendrow_2638 */
      }

      protected void SubsflControlProps_3037( )
      {
         edtavCtlcode4_Internalname = "CTLCODE4_"+sGXsfl_303_idx;
         edtavCtlname4_Internalname = "CTLNAME4_"+sGXsfl_303_idx;
         edtavCtlquantityordered3_Internalname = "CTLQUANTITYORDERED3_"+sGXsfl_303_idx;
         edtavCtlproductcostprice_Internalname = "CTLPRODUCTCOSTPRICE_"+sGXsfl_303_idx;
         edtavCtlquantityreceived2_Internalname = "CTLQUANTITYRECEIVED2_"+sGXsfl_303_idx;
         edtavCtlnewcostprice1_Internalname = "CTLNEWCOSTPRICE1_"+sGXsfl_303_idx;
      }

      protected void SubsflControlProps_fel_3037( )
      {
         edtavCtlcode4_Internalname = "CTLCODE4_"+sGXsfl_303_fel_idx;
         edtavCtlname4_Internalname = "CTLNAME4_"+sGXsfl_303_fel_idx;
         edtavCtlquantityordered3_Internalname = "CTLQUANTITYORDERED3_"+sGXsfl_303_fel_idx;
         edtavCtlproductcostprice_Internalname = "CTLPRODUCTCOSTPRICE_"+sGXsfl_303_fel_idx;
         edtavCtlquantityreceived2_Internalname = "CTLQUANTITYRECEIVED2_"+sGXsfl_303_fel_idx;
         edtavCtlnewcostprice1_Internalname = "CTLNEWCOSTPRICE1_"+sGXsfl_303_fel_idx;
      }

      protected void sendrow_3037( )
      {
         SubsflControlProps_3037( ) ;
         WB220( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0x0);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_303_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_303_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode4_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode4_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode4_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)303,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname4_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname4_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname4_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)303,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered3_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantityordered3_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Quantityordered), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Quantityordered), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlquantityordered3_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)303,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlproductcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Productcostprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlproductcostprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Productcostprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Productcostprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlproductcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlproductcostprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)303,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Quantityreceived), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantityreceived2_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Quantityreceived), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Quantityreceived), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityreceived2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlquantityreceived2_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)303,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Newcostprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlnewcostprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Newcostprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV101DetailsPay.Item(AV150GXV39)).gxTpr_Newcostprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlnewcostprice1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)303,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes227( ) ;
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_303_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_303_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_303_idx+1);
         sGXsfl_303_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_303_idx), 4, 0), 4, "0");
         SubsflControlProps_3037( ) ;
         /* End function sendrow_3037 */
      }

      protected void init_web_controls( )
      {
         dynavSupplier.Name = "vSUPPLIER";
         dynavSupplier.WebTags = "";
         cmbavOrderby.Name = "vORDERBY";
         cmbavOrderby.WebTags = "";
         cmbavOrderby.addItem("1", "Supplier", 0);
         cmbavOrderby.addItem("2", "Created", 0);
         cmbavOrderby.addItem("3", "Nro", 0);
         if ( cmbavOrderby.ItemCount > 0 )
         {
            AV52OrderBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52OrderBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52OrderBy", StringUtil.LTrimStr( (decimal)(AV52OrderBy), 4, 0));
         }
         chkavDescending.Name = "vDESCENDING";
         chkavDescending.WebTags = "";
         chkavDescending.Caption = "";
         AssignProp("", false, chkavDescending_Internalname, "TitleCaption", chkavDescending.Caption, true);
         chkavDescending.CheckedValue = "false";
         AV53Descending = StringUtil.StrToBool( StringUtil.BoolToStr( AV53Descending));
         AssignAttri("", false, "AV53Descending", AV53Descending);
         chkavIsowed.Name = "vISOWED";
         chkavIsowed.WebTags = "";
         chkavIsowed.Caption = "";
         AssignProp("", false, chkavIsowed_Internalname, "TitleCaption", chkavIsowed.Caption, true);
         chkavIsowed.CheckedValue = "false";
         AV99IsOwed = StringUtil.StrToBool( StringUtil.BoolToStr( AV99IsOwed));
         AssignAttri("", false, "AV99IsOwed", AV99IsOwed);
         /* End function init_web_controls */
      }

      protected void StartGridControl41( )
      {
         if ( GridpurchaseordersfilteredContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridpurchaseordersfilteredContainer"+"DivS\" data-gxgridid=\"41\">") ;
            sStyleString = "";
            if ( subGridpurchaseordersfiltered_Collapsed != 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGridpurchaseordersfiltered_Internalname, subGridpurchaseordersfiltered_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridpurchaseordersfiltered_Backcolorstyle == 0 )
            {
               subGridpurchaseordersfiltered_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridpurchaseordersfiltered_Class) > 0 )
               {
                  subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Title";
               }
            }
            else
            {
               subGridpurchaseordersfiltered_Titlebackstyle = 1;
               if ( subGridpurchaseordersfiltered_Backcolorstyle == 1 )
               {
                  subGridpurchaseordersfiltered_Titlebackcolor = subGridpurchaseordersfiltered_Allbackcolor;
                  if ( StringUtil.Len( subGridpurchaseordersfiltered_Class) > 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridpurchaseordersfiltered_Class) > 0 )
                  {
                     subGridpurchaseordersfiltered_Linesclass = subGridpurchaseordersfiltered_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavEdit_gximage, "")==0) ? "" : "GX_Image_"+edtavEdit_gximage+"_Class")+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCancel_gximage, "")==0) ? "" : "GX_Image_"+edtavCancel_gximage+"_Class")+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavRegister_gximage, "")==0) ? "" : "GX_Image_"+edtavRegister_gximage+"_Class")+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(24), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCtladdimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtladdimage_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(24), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCtldeleteimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtldeleteimage_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(24), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCtlmodifyimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtlmodifyimage_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(24), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCtlpaidimage_gximage, "")==0) ? "" : "GX_Image_"+edtavCtlpaidimage_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Confirmated") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Closed") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Details") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Voucher") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridpurchaseordersfilteredContainer.AddObjectProperty("GridName", "Gridpurchaseordersfiltered");
         }
         else
         {
            GridpurchaseordersfilteredContainer.AddObjectProperty("GridName", "Gridpurchaseordersfiltered");
            GridpurchaseordersfilteredContainer.AddObjectProperty("Header", subGridpurchaseordersfiltered_Header);
            GridpurchaseordersfilteredContainer.AddObjectProperty("Class", "PromptGrid");
            GridpurchaseordersfilteredContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Backcolorstyle), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("CmpContext", "");
            GridpurchaseordersfilteredContainer.AddObjectProperty("InMasterPage", "false");
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Value", context.convertURL( AV57Edit));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Value", context.convertURL( AV56Cancel));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Value", context.convertURL( AV49Register));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcreateddate_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpurchaseorderconfirmateddate_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcloseddate_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsuppliername_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtldetailslink_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseordersfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddColumnProperties(GridpurchaseordersfilteredColumn);
            GridpurchaseordersfilteredContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Selectedindex), 4, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Allowselection), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Selectioncolor), 9, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Allowhovering), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Hoveringcolor), 9, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Allowcollapsing), 1, 0, ".", "")));
            GridpurchaseordersfilteredContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseordersfiltered_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl101( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"101\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityordered_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityreceived1_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl161( )
      {
         if ( FgrideditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FgrideditContainer"+"DivS\" data-gxgridid=\"161\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFgridedit_Internalname, subFgridedit_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FgrideditContainer.AddObjectProperty("GridName", "Fgridedit");
         }
         else
         {
            FgrideditContainer.AddObjectProperty("GridName", "Fgridedit");
            FgrideditContainer.AddObjectProperty("Header", subFgridedit_Header);
            FgrideditContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FgrideditContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FgrideditContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Backcolorstyle), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("CmpContext", "");
            FgrideditContainer.AddObjectProperty("InMasterPage", "false");
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Value", context.convertURL( AV62RemoveDetail));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock1_Enabled), 5, 0, ".", "")));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgrideditContainer.AddColumnProperties(FgrideditColumn);
            FgrideditContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Selectedindex), 4, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Allowselection), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Selectioncolor), 9, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Allowhovering), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Hoveringcolor), 9, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Allowcollapsing), 1, 0, ".", "")));
            FgrideditContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridedit_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl208( )
      {
         if ( FgridposiblenewdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FgridposiblenewdetailsContainer"+"DivS\" data-gxgridid=\"208\">") ;
            sStyleString = "";
            sStyleString += " height: " + StringUtil.LTrimStr( (decimal)(30), 10, 0) + "" + ";";
            GxWebStd.gx_table_start( context, subFgridposiblenewdetails_Internalname, subFgridposiblenewdetails_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FgridposiblenewdetailsContainer.AddObjectProperty("GridName", "Fgridposiblenewdetails");
         }
         else
         {
            FgridposiblenewdetailsContainer.AddObjectProperty("GridName", "Fgridposiblenewdetails");
            FgridposiblenewdetailsContainer.AddObjectProperty("Header", subFgridposiblenewdetails_Header);
            FgridposiblenewdetailsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
            FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(30), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Class", "PromptGrid");
            FgridposiblenewdetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Backcolorstyle), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Height", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Height), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("CmpContext", "");
            FgridposiblenewdetailsContainer.AddObjectProperty("InMasterPage", "false");
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Value", context.convertURL( AV66SelectThis));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridposiblenewdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock3_Enabled), 5, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddColumnProperties(FgridposiblenewdetailsColumn);
            FgridposiblenewdetailsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Selectedindex), 4, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Allowselection), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Selectioncolor), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Allowhovering), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Hoveringcolor), 9, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Allowcollapsing), 1, 0, ".", "")));
            FgridposiblenewdetailsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridposiblenewdetails_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl263( )
      {
         if ( FgridcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"FgridcancelContainer"+"DivS\" data-gxgridid=\"263\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subFgridcancel_Internalname, subFgridcancel_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            FgridcancelContainer.AddObjectProperty("GridName", "Fgridcancel");
         }
         else
         {
            FgridcancelContainer.AddObjectProperty("GridName", "Fgridcancel");
            FgridcancelContainer.AddObjectProperty("Header", subFgridcancel_Header);
            FgridcancelContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            FgridcancelContainer.AddObjectProperty("Class", "FreeStyleGrid");
            FgridcancelContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Backcolorstyle), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("CmpContext", "");
            FgridcancelContainer.AddObjectProperty("InMasterPage", "false");
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcurrentstock2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            FgridcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityordered2_Enabled), 5, 0, ".", "")));
            FgridcancelContainer.AddColumnProperties(FgridcancelColumn);
            FgridcancelContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Selectedindex), 4, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Allowselection), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Selectioncolor), 9, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Allowhovering), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Hoveringcolor), 9, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Allowcollapsing), 1, 0, ".", "")));
            FgridcancelContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFgridcancel_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl303( )
      {
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"303\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid2_Backcolorstyle == 0 )
            {
               subGrid2_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid2_Class) > 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Title";
               }
            }
            else
            {
               subGrid2_Titlebackstyle = 1;
               if ( subGrid2_Backcolorstyle == 1 )
               {
                  subGrid2_Titlebackcolor = subGrid2_Allbackcolor;
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ordered") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Current Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Received") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sugg. Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid2Container.AddObjectProperty("GridName", "Grid2");
         }
         else
         {
            Grid2Container.AddObjectProperty("GridName", "Grid2");
            Grid2Container.AddObjectProperty("Header", subGrid2_Header);
            Grid2Container.AddObjectProperty("Class", "PromptGrid");
            Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("CmpContext", "");
            Grid2Container.AddObjectProperty("InMasterPage", "false");
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode4_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname4_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityordered3_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlproductcostprice_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityreceived2_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlnewcostprice1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavPurchaseorderidaux_Internalname = "vPURCHASEORDERIDAUX";
         dynavSupplier_Internalname = "vSUPPLIER";
         edtavFromdate_Internalname = "vFROMDATE";
         edtavTodate_Internalname = "vTODATE";
         cmbavOrderby_Internalname = "vORDERBY";
         chkavDescending_Internalname = "vDESCENDING";
         edtavEdit_Internalname = "vEDIT";
         edtavCancel_Internalname = "vCANCEL";
         edtavRegister_Internalname = "vREGISTER";
         edtavCtladdimage_Internalname = "CTLADDIMAGE";
         edtavCtldeleteimage_Internalname = "CTLDELETEIMAGE";
         edtavCtlmodifyimage_Internalname = "CTLMODIFYIMAGE";
         edtavCtlpaidimage_Internalname = "CTLPAIDIMAGE";
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID";
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE";
         edtavCtlpurchaseorderconfirmateddate_Internalname = "CTLPURCHASEORDERCONFIRMATEDDATE";
         edtavCtlcloseddate_Internalname = "CTLCLOSEDDATE";
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME";
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK";
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK";
         divTable1_Internalname = "TABLE1";
         edtavTotalpaid_Internalname = "vTOTALPAID";
         chkavIsowed_Internalname = "vISOWED";
         bttRegisterorder_Internalname = "REGISTERORDER";
         bttCancelregister_Internalname = "CANCELREGISTER";
         divTablebuttonsregister_Internalname = "TABLEBUTTONSREGISTER";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlcurrentstock_Internalname = "CTLCURRENTSTOCK";
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED";
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED";
         edtavCtlquantityreceived1_Internalname = "CTLQUANTITYRECEIVED1";
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         divGrid1table_Internalname = "GRID1TABLE";
         divTablecontentregister_Internalname = "TABLECONTENTREGISTER";
         divTableregister_Internalname = "TABLEREGISTER";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         bttConfirmchanges_Internalname = "CONFIRMCHANGES";
         bttCancel1_Internalname = "CANCEL1";
         divTablebuttonsedit_Internalname = "TABLEBUTTONSEDIT";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtavRemovedetail_Internalname = "vREMOVEDETAIL";
         edtavCtlcode1_Internalname = "CTLCODE1";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlcurrentstock1_Internalname = "CTLCURRENTSTOCK1";
         edtavCtlminiumstock1_Internalname = "CTLMINIUMSTOCK1";
         edtavCtlquantityordered1_Internalname = "CTLQUANTITYORDERED1";
         divGrid1table1_Internalname = "GRID1TABLE1";
         bttAdddetail_Internalname = "ADDDETAIL";
         bttCanceladd_Internalname = "CANCELADD";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtavSelectthis_Internalname = "vSELECTTHIS";
         edtavCtlcode3_Internalname = "CTLCODE3";
         edtavCtlname3_Internalname = "CTLNAME3";
         edtavCtlcurrentstock3_Internalname = "CTLCURRENTSTOCK3";
         edtavCtlminiumstock3_Internalname = "CTLMINIUMSTOCK3";
         divGrid2table_Internalname = "GRID2TABLE";
         divTable2_Internalname = "TABLE2";
         divTablecontentedit_Internalname = "TABLECONTENTEDIT";
         divTableedit_Internalname = "TABLEEDIT";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         bttYes_Internalname = "YES";
         bttNo_Internalname = "NO";
         divTablebuttonscancel_Internalname = "TABLEBUTTONSCANCEL";
         edtavPurchaseordercanceleddescription_Internalname = "vPURCHASEORDERCANCELEDDESCRIPTION";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtavCtlcode2_Internalname = "CTLCODE2";
         edtavCtlname2_Internalname = "CTLNAME2";
         edtavCtlcurrentstock2_Internalname = "CTLCURRENTSTOCK2";
         edtavCtlminiumstock2_Internalname = "CTLMINIUMSTOCK2";
         edtavCtlquantityordered2_Internalname = "CTLQUANTITYORDERED2";
         divGrid1table2_Internalname = "GRID1TABLE2";
         divTablecontentcancel_Internalname = "TABLECONTENTCANCEL";
         divTcancel_Internalname = "TCANCEL";
         edtavTotaltopay_Internalname = "vTOTALTOPAY";
         bttPayorder_Internalname = "PAYORDER";
         bttPaycancel_Internalname = "PAYCANCEL";
         divTablepaybuttons_Internalname = "TABLEPAYBUTTONS";
         edtavCtlcode4_Internalname = "CTLCODE4";
         edtavCtlname4_Internalname = "CTLNAME4";
         edtavCtlquantityordered3_Internalname = "CTLQUANTITYORDERED3";
         edtavCtlproductcostprice_Internalname = "CTLPRODUCTCOSTPRICE";
         edtavCtlquantityreceived2_Internalname = "CTLQUANTITYRECEIVED2";
         edtavCtlnewcostprice1_Internalname = "CTLNEWCOSTPRICE1";
         divTablepaygrid_Internalname = "TABLEPAYGRID";
         divTpay_Internalname = "TPAY";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridpurchaseordersfiltered_Internalname = "GRIDPURCHASEORDERSFILTERED";
         subGrid1_Internalname = "GRID1";
         subFgridedit_Internalname = "FGRIDEDIT";
         subFgridposiblenewdetails_Internalname = "FGRIDPOSIBLENEWDETAILS";
         subFgridcancel_Internalname = "FGRIDCANCEL";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid2_Allowcollapsing = 0;
         subGrid2_Allowselection = 0;
         subGrid2_Header = "";
         subFgridcancel_Allowcollapsing = 0;
         subFgridposiblenewdetails_Allowcollapsing = 0;
         subFgridedit_Allowcollapsing = 0;
         subGrid1_Allowcollapsing = 0;
         subGridpurchaseordersfiltered_Allowcollapsing = 1;
         subGridpurchaseordersfiltered_Allowselection = 0;
         subGridpurchaseordersfiltered_Header = "";
         chkavIsowed.Caption = "Is Owed";
         chkavDescending.Caption = "Desc";
         edtavCtlnewcostprice1_Jsonclick = "";
         edtavCtlnewcostprice1_Enabled = 0;
         edtavCtlquantityreceived2_Jsonclick = "";
         edtavCtlquantityreceived2_Enabled = 0;
         edtavCtlproductcostprice_Jsonclick = "";
         edtavCtlproductcostprice_Enabled = 0;
         edtavCtlquantityordered3_Jsonclick = "";
         edtavCtlquantityordered3_Enabled = 0;
         edtavCtlname4_Jsonclick = "";
         edtavCtlname4_Enabled = 0;
         edtavCtlcode4_Jsonclick = "";
         edtavCtlcode4_Enabled = 0;
         subGrid2_Class = "PromptGrid";
         subGrid2_Backcolorstyle = 0;
         edtavCtlquantityordered2_Jsonclick = "";
         edtavCtlquantityordered2_Enabled = 0;
         edtavCtlminiumstock2_Jsonclick = "";
         edtavCtlminiumstock2_Enabled = 0;
         edtavCtlcurrentstock2_Jsonclick = "";
         edtavCtlcurrentstock2_Enabled = 0;
         edtavCtlname2_Jsonclick = "";
         edtavCtlname2_Enabled = 0;
         edtavCtlcode2_Jsonclick = "";
         edtavCtlcode2_Enabled = 0;
         subFgridcancel_Class = "FreeStyleGrid";
         edtavCtlminiumstock3_Jsonclick = "";
         edtavCtlminiumstock3_Enabled = 0;
         edtavCtlcurrentstock3_Jsonclick = "";
         edtavCtlcurrentstock3_Enabled = 0;
         edtavCtlname3_Jsonclick = "";
         edtavCtlname3_Enabled = 0;
         edtavCtlcode3_Jsonclick = "";
         edtavCtlcode3_Enabled = 0;
         edtavSelectthis_Jsonclick = "";
         edtavSelectthis_Visible = 1;
         edtavSelectthis_Enabled = 1;
         subFgridposiblenewdetails_Class = "PromptGrid";
         edtavCtlquantityordered1_Jsonclick = "";
         edtavCtlquantityordered1_Visible = 1;
         edtavCtlquantityordered1_Enabled = 1;
         edtavCtlminiumstock1_Jsonclick = "";
         edtavCtlminiumstock1_Enabled = 0;
         edtavCtlcurrentstock1_Jsonclick = "";
         edtavCtlcurrentstock1_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         edtavCtlcode1_Jsonclick = "";
         edtavCtlcode1_Enabled = 0;
         edtavRemovedetail_Jsonclick = "";
         edtavRemovedetail_Visible = 1;
         edtavRemovedetail_Enabled = 1;
         subFgridedit_Class = "FreeStyleGrid";
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlnewcostprice_Jsonclick = "";
         edtavCtlnewcostprice_Visible = 1;
         edtavCtlnewcostprice_Enabled = 1;
         edtavCtlquantityreceived1_Jsonclick = "";
         edtavCtlquantityreceived1_Enabled = 0;
         edtavCtlquantityreceived_Jsonclick = "";
         edtavCtlquantityreceived_Visible = 1;
         edtavCtlquantityreceived_Enabled = 1;
         edtavCtlquantityordered_Jsonclick = "";
         edtavCtlquantityordered_Enabled = 0;
         edtavCtlcurrentstock_Jsonclick = "";
         edtavCtlcurrentstock_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         subGrid1_Class = "FreeStyleGrid";
         edtavCtlsdtvoucherlink_Jsonclick = "";
         edtavCtlsdtvoucherlink_Enabled = 0;
         edtavCtldetailslink_Jsonclick = "";
         edtavCtldetailslink_Enabled = 0;
         edtavCtlsuppliername_Jsonclick = "";
         edtavCtlsuppliername_Enabled = 0;
         edtavCtlcloseddate_Jsonclick = "";
         edtavCtlcloseddate_Enabled = 0;
         edtavCtlpurchaseorderconfirmateddate_Jsonclick = "";
         edtavCtlpurchaseorderconfirmateddate_Enabled = 0;
         edtavCtlcreateddate_Jsonclick = "";
         edtavCtlcreateddate_Enabled = 0;
         edtavCtlpurchaseorderid_Jsonclick = "";
         edtavCtlpurchaseorderid_Enabled = 0;
         edtavCtlpaidimage_Jsonclick = "";
         edtavCtlpaidimage_gximage = "";
         edtavCtlpaidimage_Visible = -1;
         edtavCtlpaidimage_Enabled = 1;
         edtavCtlmodifyimage_Jsonclick = "";
         edtavCtlmodifyimage_gximage = "";
         edtavCtlmodifyimage_Visible = -1;
         edtavCtlmodifyimage_Enabled = 1;
         edtavCtldeleteimage_Jsonclick = "";
         edtavCtldeleteimage_gximage = "";
         edtavCtldeleteimage_Visible = -1;
         edtavCtldeleteimage_Enabled = 1;
         edtavCtladdimage_Jsonclick = "";
         edtavCtladdimage_gximage = "";
         edtavCtladdimage_Visible = -1;
         edtavCtladdimage_Enabled = 1;
         edtavRegister_gximage = "";
         edtavCancel_gximage = "";
         edtavEdit_gximage = "";
         subGridpurchaseordersfiltered_Class = "PromptGrid";
         subGridpurchaseordersfiltered_Backcolorstyle = 0;
         edtavSelectthis_gximage = "";
         edtavRemovedetail_gximage = "";
         subGrid1_Backcolorstyle = 0;
         subFgridedit_Backcolorstyle = 0;
         subFgridposiblenewdetails_Height = 30;
         subFgridposiblenewdetails_Backcolorstyle = 0;
         subFgridcancel_Backcolorstyle = 0;
         edtavCtlnewcostprice1_Enabled = -1;
         edtavCtlquantityreceived2_Enabled = -1;
         edtavCtlproductcostprice_Enabled = -1;
         edtavCtlquantityordered3_Enabled = -1;
         edtavCtlname4_Enabled = -1;
         edtavCtlcode4_Enabled = -1;
         edtavCtlquantityordered2_Enabled = -1;
         edtavCtlminiumstock2_Enabled = -1;
         edtavCtlcurrentstock2_Enabled = -1;
         edtavCtlname2_Enabled = -1;
         edtavCtlcode2_Enabled = -1;
         edtavCtlminiumstock3_Enabled = -1;
         edtavCtlcurrentstock3_Enabled = -1;
         edtavCtlname3_Enabled = -1;
         edtavCtlcode3_Enabled = -1;
         edtavCtlminiumstock1_Enabled = -1;
         edtavCtlcurrentstock1_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlcode1_Enabled = -1;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlquantityreceived1_Enabled = -1;
         edtavCtlquantityordered_Enabled = -1;
         edtavCtlcurrentstock_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         edtavCtlsdtvoucherlink_Enabled = -1;
         edtavCtldetailslink_Enabled = -1;
         edtavCtlsuppliername_Enabled = -1;
         edtavCtlcloseddate_Enabled = -1;
         edtavCtlpurchaseorderconfirmateddate_Enabled = -1;
         edtavCtlcreateddate_Enabled = -1;
         edtavCtlpurchaseorderid_Enabled = -1;
         edtavTotaltopay_Jsonclick = "";
         edtavTotaltopay_Enabled = 1;
         divTpay_Visible = 1;
         edtavPurchaseordercanceleddescription_Enabled = 1;
         divTcancel_Visible = 1;
         divTable2_Visible = 1;
         bttCanceladd_Visible = 1;
         bttAdddetail_Enabled = 1;
         bttAdddetail_Visible = 1;
         divTableedit_Visible = 1;
         chkavIsowed.Enabled = 1;
         edtavTotalpaid_Jsonclick = "";
         edtavTotalpaid_Enabled = 1;
         divTableregister_Visible = 1;
         chkavDescending.Enabled = 1;
         cmbavOrderby_Jsonclick = "";
         cmbavOrderby.Enabled = 1;
         edtavTodate_Jsonclick = "";
         edtavTodate_Enabled = 1;
         edtavFromdate_Jsonclick = "";
         edtavFromdate_Enabled = 1;
         dynavSupplier_Jsonclick = "";
         dynavSupplier.Enabled = 1;
         edtavPurchaseorderidaux_Jsonclick = "";
         edtavPurchaseorderidaux_Enabled = 1;
         subGridpurchaseordersfiltered_Collapsed = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPManage Purchase";
         subGridpurchaseordersfiltered_Rows = 5;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'REGISTERORDER'","{handler:'E13222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A8SupplierEmail',fld:'SUPPLIEREMAIL',pic:''},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'A52PurchaseOrderCreatedDate',fld:'PURCHASEORDERCREATEDDATE',pic:''},{av:'A78PurchaseOrderTotalPaid',fld:'PURCHASEORDERTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV90EmailPurchaseOrderId',fld:'vEMAILPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'AV87EmailCreatedDate',fld:'vEMAILCREATEDDATE',pic:''},{av:'AV88EmailTotalPaid',fld:'vEMAILTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nEOF'}]");
         setEventMetadata("'REGISTERORDER'",",oparms:[{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV87EmailCreatedDate',fld:'vEMAILCREATEDDATE',pic:''},{av:'AV88EmailTotalPaid',fld:'vEMAILTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV90EmailPurchaseOrderId',fld:'vEMAILPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''}]}");
         setEventMetadata("'CANCELREGISTER'","{handler:'E14222',iparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("'CANCELREGISTER'",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'}]}");
         setEventMetadata("'CANCELEDIT'","{handler:'E15222',iparms:[{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("'CANCELEDIT'",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'}]}");
         setEventMetadata("'CANCELCANCEL'","{handler:'E16222',iparms:[{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nEOF'},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("'CANCELCANCEL'",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'}]}");
         setEventMetadata("'CONFIRM'","{handler:'E17222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A8SupplierEmail',fld:'SUPPLIEREMAIL',pic:''},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV90EmailPurchaseOrderId',fld:'vEMAILPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV87EmailCreatedDate',fld:'vEMAILCREATEDDATE',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101}]");
         setEventMetadata("'CONFIRM'",",oparms:[{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''}]}");
         setEventMetadata("CTLADDIMAGE.CLICK","{handler:'E33222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("CTLADDIMAGE.CLICK",",oparms:[{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'divTpay_Visible',ctrl:'TPAY',prop:'Visible'}]}");
         setEventMetadata("CTLPAIDIMAGE.CLICK","{handler:'E34222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nEOF'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("CTLPAIDIMAGE.CLICK",",oparms:[{av:'AV102TotalToPay',fld:'vTOTALTOPAY',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'divTpay_Visible',ctrl:'TPAY',prop:'Visible'},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'}]}");
         setEventMetadata("CTLDELETEIMAGE.CLICK","{handler:'E35222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nEOF'},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("CTLDELETEIMAGE.CLICK",",oparms:[{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTpay_Visible',ctrl:'TPAY',prop:'Visible'}]}");
         setEventMetadata("CTLMODIFYIMAGE.CLICK","{handler:'E36222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("CTLMODIFYIMAGE.CLICK",",oparms:[{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'},{ctrl:'ADDDETAIL',prop:'Enabled'},{ctrl:'ADDDETAIL',prop:'Visible'},{ctrl:'CANCELADD',prop:'Visible'},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'divTpay_Visible',ctrl:'TPAY',prop:'Visible'}]}");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK","{handler:'E37222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41}]");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK",",oparms:[]}");
         setEventMetadata("CTLDETAILSLINK.CLICK","{handler:'E38222',iparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41}]");
         setEventMetadata("CTLDETAILSLINK.CLICK",",oparms:[]}");
         setEventMetadata("CTLQUANTITYRECEIVED.CONTROLVALUECHANGED","{handler:'E21222',iparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("CTLQUANTITYRECEIVED.CONTROLVALUECHANGED",",oparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("CTLNEWCOSTPRICE.CONTROLVALUECHANGED","{handler:'E22222',iparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nEOF'},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("CTLNEWCOSTPRICE.CONTROLVALUECHANGED",",oparms:[{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'AV37TotalPaid',fld:'vTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("'YES'","{handler:'E18222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''},{av:'AV71ControlPassed',fld:'vCONTROLPASSED',pic:''},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV70PurchaseOrderCanceledDescription',fld:'vPURCHASEORDERCANCELEDDESCRIPTION',pic:''},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A8SupplierEmail',fld:'SUPPLIEREMAIL',pic:''},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'A52PurchaseOrderCreatedDate',fld:'PURCHASEORDERCREATEDDATE',pic:''},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'AV90EmailPurchaseOrderId',fld:'vEMAILPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV87EmailCreatedDate',fld:'vEMAILCREATEDDATE',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101}]");
         setEventMetadata("'YES'",",oparms:[{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV71ControlPassed',fld:'vCONTROLPASSED',pic:''},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV90EmailPurchaseOrderId',fld:'vEMAILPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV87EmailCreatedDate',fld:'vEMAILCREATEDDATE',pic:''},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV54AllOk',fld:'vALLOK',pic:''}]}");
         setEventMetadata("'ADDDETAIL'","{handler:'E11221',iparms:[]");
         setEventMetadata("'ADDDETAIL'",",oparms:[{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'},{ctrl:'ADDDETAIL',prop:'Visible'},{ctrl:'CANCELADD',prop:'Visible'}]}");
         setEventMetadata("'CANCELADD'","{handler:'E12221',iparms:[]");
         setEventMetadata("'CANCELADD'",",oparms:[{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'},{ctrl:'ADDDETAIL',prop:'Visible'},{ctrl:'CANCELADD',prop:'Visible'}]}");
         setEventMetadata("VSELECTTHIS.CLICK","{handler:'E27222',iparms:[{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("VSELECTTHIS.CLICK",",oparms:[{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'},{ctrl:'ADDDETAIL',prop:'Enabled'}]}");
         setEventMetadata("VREMOVEDETAIL.CLICK","{handler:'E24222',iparms:[{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'FGRIDEDIT_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("VREMOVEDETAIL.CLICK",",oparms:[{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{ctrl:'ADDDETAIL',prop:'Enabled'}]}");
         setEventMetadata("FGRIDEDIT.REFRESH","{handler:'E25222',iparms:[]");
         setEventMetadata("FGRIDEDIT.REFRESH",",oparms:[{av:'AV62RemoveDetail',fld:'vREMOVEDETAIL',pic:''}]}");
         setEventMetadata("FGRIDPOSIBLENEWDETAILS.REFRESH","{handler:'E28222',iparms:[]");
         setEventMetadata("FGRIDPOSIBLENEWDETAILS.REFRESH",",oparms:[{av:'AV66SelectThis',fld:'vSELECTTHIS',pic:''}]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED.REFRESH","{handler:'E39222',iparms:[{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED.REFRESH",",oparms:[{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'AV26FromDate',fld:'vFROMDATE',pic:''}]}");
         setEventMetadata("'PAYORDER'","{handler:'E19222',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''},{av:'AV71ControlPassed',fld:'vCONTROLPASSED',pic:''},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV102TotalToPay',fld:'vTOTALTOPAY',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A8SupplierEmail',fld:'SUPPLIEREMAIL',pic:''},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'A52PurchaseOrderCreatedDate',fld:'PURCHASEORDERCREATEDDATE',pic:''},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'AV90EmailPurchaseOrderId',fld:'vEMAILPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV87EmailCreatedDate',fld:'vEMAILCREATEDDATE',pic:''},{av:'AV88EmailTotalPaid',fld:'vEMAILTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'GRID2_nEOF'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101}]");
         setEventMetadata("'PAYORDER'",",oparms:[{av:'AV90EmailPurchaseOrderId',fld:'vEMAILPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV87EmailCreatedDate',fld:'vEMAILCREATEDDATE',pic:''},{av:'AV88EmailTotalPaid',fld:'vEMAILTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV102TotalToPay',fld:'vTOTALTOPAY',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV71ControlPassed',fld:'vCONTROLPASSED',pic:''},{av:'AV91EmailSupplierEmail',fld:'vEMAILSUPPLIEREMAIL',pic:''},{av:'AV76EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV54AllOk',fld:'vALLOK',pic:''},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'divTpay_Visible',ctrl:'TPAY',prop:'Visible'}]}");
         setEventMetadata("'PAYCANCEL'","{handler:'E20222',iparms:[{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'GRID2_nEOF'},{av:'FGRIDCANCEL_nFirstRecordOnPage'},{av:'FGRIDCANCEL_nEOF'},{av:'AV60DetailsCancel',fld:'vDETAILSCANCEL',grid:263,pic:''},{av:'nGXsfl_263_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:263},{av:'nRC_GXsfl_263',ctrl:'FGRIDCANCEL',prop:'GridRC',grid:263},{av:'FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage'},{av:'FGRIDPOSIBLENEWDETAILS_nEOF'},{av:'AV65PosiblesNewDetails',fld:'vPOSIBLESNEWDETAILS',grid:208,pic:''},{av:'nGXsfl_208_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:208},{av:'nRC_GXsfl_208',ctrl:'FGRIDPOSIBLENEWDETAILS',prop:'GridRC',grid:208},{av:'FGRIDEDIT_nFirstRecordOnPage'},{av:'FGRIDEDIT_nEOF'},{av:'AV59DetailsEdit',fld:'vDETAILSEDIT',grid:161,pic:''},{av:'nGXsfl_161_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:161},{av:'nRC_GXsfl_161',ctrl:'FGRIDEDIT',prop:'GridRC',grid:161},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV61DetailsRegister',fld:'vDETAILSREGISTER',grid:101,pic:''},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID1',prop:'GridRC',grid:101},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("'PAYCANCEL'",",oparms:[{av:'AV102TotalToPay',fld:'vTOTALTOPAY',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV101DetailsPay',fld:'vDETAILSPAY',grid:303,pic:''},{av:'nGXsfl_303_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:303},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_303',ctrl:'GRID2',prop:'GridRC',grid:303},{av:'AV55PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'divTableregister_Visible',ctrl:'TABLEREGISTER',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'divTcancel_Visible',ctrl:'TCANCEL',prop:'Visible'},{av:'divTpay_Visible',ctrl:'TPAY',prop:'Visible'}]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_FIRSTPAGE","{handler:'subgridpurchaseordersfiltered_firstpage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_PREVPAGE","{handler:'subgridpurchaseordersfiltered_previouspage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_NEXTPAGE","{handler:'subgridpurchaseordersfiltered_nextpage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_LASTPAGE","{handler:'subgridpurchaseordersfiltered_lastpage',iparms:[{av:'GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERSFILTERED_nEOF'},{av:'AV46SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:41,pic:''},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'GridRC',grid:41},{av:'subGridpurchaseordersfiltered_Rows',ctrl:'GRIDPURCHASEORDERSFILTERED',prop:'Rows'},{av:'AV69PurchaseOrderIdAux',fld:'vPURCHASEORDERIDAUX',pic:'ZZZZZ9'},{av:'AV26FromDate',fld:'vFROMDATE',pic:''},{av:'AV27ToDate',fld:'vTODATE',pic:''},{av:'cmbavOrderby'},{av:'AV52OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'dynavSupplier'},{av:'AV24Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV53Descending',fld:'vDESCENDING',pic:''},{av:'AV99IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDPURCHASEORDERSFILTERED_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_FROMDATE","{handler:'Validv_Fromdate',iparms:[]");
         setEventMetadata("VALIDV_FROMDATE",",oparms:[]}");
         setEventMetadata("VALIDV_TODATE","{handler:'Validv_Todate',iparms:[]");
         setEventMetadata("VALIDV_TODATE",",oparms:[]}");
         setEventMetadata("VALIDV_ORDERBY","{handler:'Validv_Orderby',iparms:[]");
         setEventMetadata("VALIDV_ORDERBY",",oparms:[]}");
         setEventMetadata("VALIDV_TOTALPAID","{handler:'Validv_Totalpaid',iparms:[]");
         setEventMetadata("VALIDV_TOTALPAID",",oparms:[]}");
         setEventMetadata("VALIDV_TOTALTOPAY","{handler:'Validv_Totaltopay',iparms:[]");
         setEventMetadata("VALIDV_TOTALTOPAY",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv12',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV19","{handler:'Validv_Gxv19',iparms:[]");
         setEventMetadata("VALIDV_GXV19",",oparms:[]}");
         setEventMetadata("VALIDV_GXV20","{handler:'Validv_Gxv20',iparms:[]");
         setEventMetadata("VALIDV_GXV20",",oparms:[]}");
         setEventMetadata("VALIDV_GXV21","{handler:'Validv_Gxv21',iparms:[]");
         setEventMetadata("VALIDV_GXV21",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv27',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv32',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv38',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV43","{handler:'Validv_Gxv43',iparms:[]");
         setEventMetadata("VALIDV_GXV43",",oparms:[]}");
         setEventMetadata("VALIDV_GXV45","{handler:'Validv_Gxv45',iparms:[]");
         setEventMetadata("VALIDV_GXV45",",oparms:[]}");
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
         AV26FromDate = DateTime.MinValue;
         AV27ToDate = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV61DetailsRegister = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV59DetailsEdit = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV65PosiblesNewDetails = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV60DetailsCancel = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV101DetailsPay = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV46SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
         A8SupplierEmail = "";
         A5SupplierName = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         AV76EmailBody = "";
         AV91EmailSupplierEmail = "";
         AV87EmailCreatedDate = DateTime.MinValue;
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         GridpurchaseordersfilteredContainer = new GXWebGrid( context);
         sStyleString = "";
         bttRegisterorder_Jsonclick = "";
         bttCancelregister_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         lblTextblock21_Jsonclick = "";
         bttConfirmchanges_Jsonclick = "";
         bttCancel1_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         FgrideditContainer = new GXWebGrid( context);
         bttAdddetail_Jsonclick = "";
         bttCanceladd_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
         FgridposiblenewdetailsContainer = new GXWebGrid( context);
         lblTextblock15_Jsonclick = "";
         bttYes_Jsonclick = "";
         bttNo_Jsonclick = "";
         AV70PurchaseOrderCanceledDescription = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         FgridcancelContainer = new GXWebGrid( context);
         bttPayorder_Jsonclick = "";
         bttPaycancel_Jsonclick = "";
         Grid2Container = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV62RemoveDetail = "";
         AV162Removedetail_GXI = "";
         AV66SelectThis = "";
         AV163Selectthis_GXI = "";
         AV57Edit = "";
         AV169Edit_GXI = "";
         AV56Cancel = "";
         AV168Cancel_GXI = "";
         AV49Register = "";
         AV170Register_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00222_A4SupplierId = new int[1] ;
         H00222_A5SupplierName = new string[] {""} ;
         AV12Order = new SdtPurchaseOrder(context);
         AV67Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV68WebSession = context.GetSession();
         AV40OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2 = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV48window = new GXWindow();
         GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4 = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
         H00223_A4SupplierId = new int[1] ;
         H00223_A50PurchaseOrderId = new int[1] ;
         H00223_A8SupplierEmail = new string[] {""} ;
         H00223_n8SupplierEmail = new bool[] {false} ;
         H00223_A5SupplierName = new string[] {""} ;
         H00223_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H00223_A78PurchaseOrderTotalPaid = new decimal[1] ;
         H00223_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         AV86EmailSupplierName = "";
         AV74EmailTitle = "";
         AV75EmailSubtitle = "";
         AV72URLs = new GxSimpleCollection<string>();
         AV73NamesOfAttachs = new GxSimpleCollection<string>();
         AV77EmailBodyAux = "";
         AV89EmailRegisteredDate = DateTime.MinValue;
         H00224_A4SupplierId = new int[1] ;
         H00224_A50PurchaseOrderId = new int[1] ;
         H00224_A8SupplierEmail = new string[] {""} ;
         H00224_n8SupplierEmail = new bool[] {false} ;
         H00224_A5SupplierName = new string[] {""} ;
         AV93EmailModifiedDate = DateTime.MinValue;
         H00225_A4SupplierId = new int[1] ;
         H00225_A50PurchaseOrderId = new int[1] ;
         H00225_A8SupplierEmail = new string[] {""} ;
         H00225_n8SupplierEmail = new bool[] {false} ;
         H00225_A5SupplierName = new string[] {""} ;
         H00225_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         AV94EmailCanceledDate = DateTime.MinValue;
         AV103PurchaseOrder = new SdtPurchaseOrder(context);
         H00226_A4SupplierId = new int[1] ;
         H00226_A50PurchaseOrderId = new int[1] ;
         H00226_A8SupplierEmail = new string[] {""} ;
         H00226_n8SupplierEmail = new bool[] {false} ;
         H00226_A5SupplierName = new string[] {""} ;
         H00226_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         GXt_char5 = "";
         AV105EmailPaidDate = DateTime.MinValue;
         GridpurchaseordersfilteredRow = new GXWebRow();
         Grid2Row = new GXWebRow();
         FgridcancelRow = new GXWebRow();
         FgridposiblenewdetailsRow = new GXWebRow();
         FgrideditRow = new GXWebRow();
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridpurchaseordersfiltered_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         subGrid1_Linesclass = "";
         subFgridedit_Linesclass = "";
         subFgridposiblenewdetails_Linesclass = "";
         subFgridcancel_Linesclass = "";
         subGrid2_Linesclass = "";
         GridpurchaseordersfilteredColumn = new GXWebColumn();
         subGrid1_Header = "";
         Grid1Column = new GXWebColumn();
         subFgridedit_Header = "";
         FgrideditColumn = new GXWebColumn();
         subFgridposiblenewdetails_Header = "";
         FgridposiblenewdetailsColumn = new GXWebColumn();
         subFgridcancel_Header = "";
         FgridcancelColumn = new GXWebColumn();
         Grid2Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpmanagepurchase__default(),
            new Object[][] {
                new Object[] {
               H00222_A4SupplierId, H00222_A5SupplierName
               }
               , new Object[] {
               H00223_A4SupplierId, H00223_A50PurchaseOrderId, H00223_A8SupplierEmail, H00223_n8SupplierEmail, H00223_A5SupplierName, H00223_A52PurchaseOrderCreatedDate, H00223_A78PurchaseOrderTotalPaid, H00223_n78PurchaseOrderTotalPaid
               }
               , new Object[] {
               H00224_A4SupplierId, H00224_A50PurchaseOrderId, H00224_A8SupplierEmail, H00224_n8SupplierEmail, H00224_A5SupplierName
               }
               , new Object[] {
               H00225_A4SupplierId, H00225_A50PurchaseOrderId, H00225_A8SupplierEmail, H00225_n8SupplierEmail, H00225_A5SupplierName, H00225_A52PurchaseOrderCreatedDate
               }
               , new Object[] {
               H00226_A4SupplierId, H00226_A50PurchaseOrderId, H00226_A8SupplierEmail, H00226_n8SupplierEmail, H00226_A5SupplierName, H00226_A52PurchaseOrderCreatedDate
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlpurchaseorderid_Enabled = 0;
         edtavCtlcreateddate_Enabled = 0;
         edtavCtlpurchaseorderconfirmateddate_Enabled = 0;
         edtavCtlcloseddate_Enabled = 0;
         edtavCtlsuppliername_Enabled = 0;
         edtavCtldetailslink_Enabled = 0;
         edtavCtlsdtvoucherlink_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlcurrentstock_Enabled = 0;
         edtavCtlquantityordered_Enabled = 0;
         edtavCtlquantityreceived1_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlcode1_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlcurrentstock1_Enabled = 0;
         edtavCtlminiumstock1_Enabled = 0;
         edtavCtlcode3_Enabled = 0;
         edtavCtlname3_Enabled = 0;
         edtavCtlcurrentstock3_Enabled = 0;
         edtavCtlminiumstock3_Enabled = 0;
         edtavCtlcode2_Enabled = 0;
         edtavCtlname2_Enabled = 0;
         edtavCtlcurrentstock2_Enabled = 0;
         edtavCtlminiumstock2_Enabled = 0;
         edtavCtlquantityordered2_Enabled = 0;
         edtavCtlcode4_Enabled = 0;
         edtavCtlname4_Enabled = 0;
         edtavCtlquantityordered3_Enabled = 0;
         edtavCtlproductcostprice_Enabled = 0;
         edtavCtlquantityreceived2_Enabled = 0;
         edtavCtlnewcostprice1_Enabled = 0;
      }

      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short GRIDPURCHASEORDERSFILTERED_nEOF ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV52OrderBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short subGridpurchaseordersfiltered_Collapsed ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridpurchaseordersfiltered_Backcolorstyle ;
      private short subGrid2_Backcolorstyle ;
      private short subFgridcancel_Backcolorstyle ;
      private short subFgridposiblenewdetails_Backcolorstyle ;
      private short subFgridedit_Backcolorstyle ;
      private short subGrid1_Backcolorstyle ;
      private short GRID2_nEOF ;
      private short FGRIDCANCEL_nEOF ;
      private short FGRIDPOSIBLENEWDETAILS_nEOF ;
      private short FGRIDEDIT_nEOF ;
      private short GRID1_nEOF ;
      private short AV109Count ;
      private short nGXWrapped ;
      private short subGridpurchaseordersfiltered_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subFgridedit_Backstyle ;
      private short subFgridposiblenewdetails_Backstyle ;
      private short subFgridcancel_Backstyle ;
      private short subGrid2_Backstyle ;
      private short subGridpurchaseordersfiltered_Titlebackstyle ;
      private short subGridpurchaseordersfiltered_Allowselection ;
      private short subGridpurchaseordersfiltered_Allowhovering ;
      private short subGridpurchaseordersfiltered_Allowcollapsing ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subFgridedit_Allowselection ;
      private short subFgridedit_Allowhovering ;
      private short subFgridedit_Allowcollapsing ;
      private short subFgridedit_Collapsed ;
      private short subFgridposiblenewdetails_Allowselection ;
      private short subFgridposiblenewdetails_Allowhovering ;
      private short subFgridposiblenewdetails_Allowcollapsing ;
      private short subFgridposiblenewdetails_Collapsed ;
      private short subFgridcancel_Allowselection ;
      private short subFgridcancel_Allowhovering ;
      private short subFgridcancel_Allowcollapsing ;
      private short subFgridcancel_Collapsed ;
      private short subGrid2_Titlebackstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private int nRC_GXsfl_41 ;
      private int nRC_GXsfl_101 ;
      private int nRC_GXsfl_161 ;
      private int nRC_GXsfl_208 ;
      private int nRC_GXsfl_263 ;
      private int nRC_GXsfl_303 ;
      private int subGridpurchaseordersfiltered_Rows ;
      private int nGXsfl_41_idx=1 ;
      private int AV69PurchaseOrderIdAux ;
      private int AV24Supplier ;
      private int nGXsfl_101_idx=1 ;
      private int nGXsfl_161_idx=1 ;
      private int nGXsfl_208_idx=1 ;
      private int nGXsfl_263_idx=1 ;
      private int nGXsfl_303_idx=1 ;
      private int AV55PurchaseOrderId ;
      private int A50PurchaseOrderId ;
      private int AV90EmailPurchaseOrderId ;
      private int edtavPurchaseorderidaux_Enabled ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int AV112GXV1 ;
      private int divTableregister_Visible ;
      private int edtavTotalpaid_Enabled ;
      private int AV124GXV13 ;
      private int divTableedit_Visible ;
      private int AV133GXV22 ;
      private int bttAdddetail_Visible ;
      private int bttAdddetail_Enabled ;
      private int bttCanceladd_Visible ;
      private int divTable2_Visible ;
      private int AV139GXV28 ;
      private int divTcancel_Visible ;
      private int edtavPurchaseordercanceleddescription_Enabled ;
      private int AV144GXV33 ;
      private int divTpay_Visible ;
      private int edtavTotaltopay_Enabled ;
      private int AV150GXV39 ;
      private int gxdynajaxindex ;
      private int subGridpurchaseordersfiltered_Islastpage ;
      private int subGrid2_Islastpage ;
      private int subFgridcancel_Islastpage ;
      private int subFgridposiblenewdetails_Islastpage ;
      private int subFgridedit_Islastpage ;
      private int subGrid1_Islastpage ;
      private int edtavCtlpurchaseorderid_Enabled ;
      private int edtavCtlcreateddate_Enabled ;
      private int edtavCtlpurchaseorderconfirmateddate_Enabled ;
      private int edtavCtlcloseddate_Enabled ;
      private int edtavCtlsuppliername_Enabled ;
      private int edtavCtldetailslink_Enabled ;
      private int edtavCtlsdtvoucherlink_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlcurrentstock_Enabled ;
      private int edtavCtlquantityordered_Enabled ;
      private int edtavCtlquantityreceived1_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int edtavCtlcode1_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlcurrentstock1_Enabled ;
      private int edtavCtlminiumstock1_Enabled ;
      private int edtavCtlcode3_Enabled ;
      private int edtavCtlname3_Enabled ;
      private int edtavCtlcurrentstock3_Enabled ;
      private int edtavCtlminiumstock3_Enabled ;
      private int edtavCtlcode2_Enabled ;
      private int edtavCtlname2_Enabled ;
      private int edtavCtlcurrentstock2_Enabled ;
      private int edtavCtlminiumstock2_Enabled ;
      private int edtavCtlquantityordered2_Enabled ;
      private int edtavCtlcode4_Enabled ;
      private int edtavCtlname4_Enabled ;
      private int edtavCtlquantityordered3_Enabled ;
      private int edtavCtlproductcostprice_Enabled ;
      private int edtavCtlquantityreceived2_Enabled ;
      private int edtavCtlnewcostprice1_Enabled ;
      private int GRIDPURCHASEORDERSFILTERED_nGridOutOfScope ;
      private int subFgridposiblenewdetails_Height ;
      private int nGXsfl_41_fel_idx=1 ;
      private int nGXsfl_101_fel_idx=1 ;
      private int nGXsfl_161_fel_idx=1 ;
      private int nGXsfl_208_fel_idx=1 ;
      private int nGXsfl_263_fel_idx=1 ;
      private int nGXsfl_303_fel_idx=1 ;
      private int nGXsfl_101_bak_idx=1 ;
      private int nGXsfl_161_bak_idx=1 ;
      private int nGXsfl_263_bak_idx=1 ;
      private int AV157GXV46 ;
      private int nGXsfl_303_bak_idx=1 ;
      private int nGXsfl_208_bak_idx=1 ;
      private int AV158GXV47 ;
      private int AV159GXV48 ;
      private int AV160GXV49 ;
      private int nGXsfl_41_bak_idx=1 ;
      private int AV161GXV50 ;
      private int A4SupplierId ;
      private int idxLst ;
      private int subGridpurchaseordersfiltered_Backcolor ;
      private int subGridpurchaseordersfiltered_Allbackcolor ;
      private int edtavCtladdimage_Enabled ;
      private int edtavCtladdimage_Visible ;
      private int edtavCtldeleteimage_Enabled ;
      private int edtavCtldeleteimage_Visible ;
      private int edtavCtlmodifyimage_Enabled ;
      private int edtavCtlmodifyimage_Visible ;
      private int edtavCtlpaidimage_Enabled ;
      private int edtavCtlpaidimage_Visible ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavCtlquantityreceived_Enabled ;
      private int edtavCtlquantityreceived_Visible ;
      private int edtavCtlnewcostprice_Enabled ;
      private int edtavCtlnewcostprice_Visible ;
      private int subFgridedit_Backcolor ;
      private int subFgridedit_Allbackcolor ;
      private int edtavRemovedetail_Enabled ;
      private int edtavRemovedetail_Visible ;
      private int edtavCtlquantityordered1_Enabled ;
      private int edtavCtlquantityordered1_Visible ;
      private int subFgridposiblenewdetails_Backcolor ;
      private int subFgridposiblenewdetails_Allbackcolor ;
      private int edtavSelectthis_Enabled ;
      private int edtavSelectthis_Visible ;
      private int subFgridcancel_Backcolor ;
      private int subFgridcancel_Allbackcolor ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int subGridpurchaseordersfiltered_Titlebackcolor ;
      private int subGridpurchaseordersfiltered_Selectedindex ;
      private int subGridpurchaseordersfiltered_Selectioncolor ;
      private int subGridpurchaseordersfiltered_Hoveringcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subFgridedit_Selectedindex ;
      private int subFgridedit_Selectioncolor ;
      private int subFgridedit_Hoveringcolor ;
      private int subFgridposiblenewdetails_Selectedindex ;
      private int subFgridposiblenewdetails_Selectioncolor ;
      private int subFgridposiblenewdetails_Hoveringcolor ;
      private int subFgridcancel_Selectedindex ;
      private int subFgridcancel_Selectioncolor ;
      private int subFgridcancel_Hoveringcolor ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private long GRIDPURCHASEORDERSFILTERED_nFirstRecordOnPage ;
      private long GRIDPURCHASEORDERSFILTERED_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long FGRIDEDIT_nCurrentRecord ;
      private long FGRIDPOSIBLENEWDETAILS_nCurrentRecord ;
      private long FGRIDCANCEL_nCurrentRecord ;
      private long GRID2_nCurrentRecord ;
      private long GRIDPURCHASEORDERSFILTERED_nRecordCount ;
      private long GRID2_nFirstRecordOnPage ;
      private long FGRIDCANCEL_nFirstRecordOnPage ;
      private long FGRIDPOSIBLENEWDETAILS_nFirstRecordOnPage ;
      private long FGRIDEDIT_nFirstRecordOnPage ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal AV88EmailTotalPaid ;
      private decimal AV37TotalPaid ;
      private decimal AV102TotalToPay ;
      private decimal GXt_decimal3 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_41_idx="0001" ;
      private string sGXsfl_101_idx="0001" ;
      private string sGXsfl_161_idx="0001" ;
      private string sGXsfl_208_idx="0001" ;
      private string sGXsfl_263_idx="0001" ;
      private string sGXsfl_303_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable1_Internalname ;
      private string edtavPurchaseorderidaux_Internalname ;
      private string TempTags ;
      private string edtavPurchaseorderidaux_Jsonclick ;
      private string dynavSupplier_Internalname ;
      private string dynavSupplier_Jsonclick ;
      private string edtavFromdate_Internalname ;
      private string edtavFromdate_Jsonclick ;
      private string edtavTodate_Internalname ;
      private string edtavTodate_Jsonclick ;
      private string cmbavOrderby_Internalname ;
      private string cmbavOrderby_Jsonclick ;
      private string chkavDescending_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGridpurchaseordersfiltered_Internalname ;
      private string divTableregister_Internalname ;
      private string divTablebuttonsregister_Internalname ;
      private string edtavTotalpaid_Internalname ;
      private string edtavTotalpaid_Jsonclick ;
      private string chkavIsowed_Internalname ;
      private string bttRegisterorder_Internalname ;
      private string bttRegisterorder_Jsonclick ;
      private string bttCancelregister_Internalname ;
      private string bttCancelregister_Jsonclick ;
      private string divTablecontentregister_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string subGrid1_Internalname ;
      private string divTableedit_Internalname ;
      private string divTablebuttonsedit_Internalname ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string bttConfirmchanges_Internalname ;
      private string bttConfirmchanges_Jsonclick ;
      private string bttCancel1_Internalname ;
      private string bttCancel1_Jsonclick ;
      private string divTablecontentedit_Internalname ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string subFgridedit_Internalname ;
      private string bttAdddetail_Internalname ;
      private string bttAdddetail_Jsonclick ;
      private string bttCanceladd_Internalname ;
      private string bttCanceladd_Jsonclick ;
      private string divTable2_Internalname ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string subFgridposiblenewdetails_Internalname ;
      private string divTcancel_Internalname ;
      private string divTablebuttonscancel_Internalname ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string bttYes_Internalname ;
      private string bttYes_Jsonclick ;
      private string bttNo_Internalname ;
      private string bttNo_Jsonclick ;
      private string edtavPurchaseordercanceleddescription_Internalname ;
      private string divTablecontentcancel_Internalname ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string subFgridcancel_Internalname ;
      private string divTpay_Internalname ;
      private string divTablepaybuttons_Internalname ;
      private string edtavTotaltopay_Internalname ;
      private string edtavTotaltopay_Jsonclick ;
      private string bttPayorder_Internalname ;
      private string bttPayorder_Jsonclick ;
      private string bttPaycancel_Internalname ;
      private string bttPaycancel_Jsonclick ;
      private string divTablepaygrid_Internalname ;
      private string subGrid2_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavRemovedetail_Internalname ;
      private string edtavSelectthis_Internalname ;
      private string edtavEdit_Internalname ;
      private string edtavCancel_Internalname ;
      private string edtavRegister_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlpurchaseorderid_Internalname ;
      private string edtavCtlcreateddate_Internalname ;
      private string edtavCtlpurchaseorderconfirmateddate_Internalname ;
      private string edtavCtlcloseddate_Internalname ;
      private string edtavCtlsuppliername_Internalname ;
      private string edtavCtldetailslink_Internalname ;
      private string edtavCtlsdtvoucherlink_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlcurrentstock_Internalname ;
      private string edtavCtlquantityordered_Internalname ;
      private string edtavCtlquantityreceived1_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string edtavCtlcode1_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlcurrentstock1_Internalname ;
      private string edtavCtlminiumstock1_Internalname ;
      private string edtavCtlcode3_Internalname ;
      private string edtavCtlname3_Internalname ;
      private string edtavCtlcurrentstock3_Internalname ;
      private string edtavCtlminiumstock3_Internalname ;
      private string edtavCtlcode2_Internalname ;
      private string edtavCtlname2_Internalname ;
      private string edtavCtlcurrentstock2_Internalname ;
      private string edtavCtlminiumstock2_Internalname ;
      private string edtavCtlquantityordered2_Internalname ;
      private string edtavCtlcode4_Internalname ;
      private string edtavCtlname4_Internalname ;
      private string edtavCtlquantityordered3_Internalname ;
      private string edtavCtlproductcostprice_Internalname ;
      private string edtavCtlquantityreceived2_Internalname ;
      private string edtavCtlnewcostprice1_Internalname ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string sGXsfl_101_fel_idx="0001" ;
      private string sGXsfl_161_fel_idx="0001" ;
      private string sGXsfl_208_fel_idx="0001" ;
      private string sGXsfl_263_fel_idx="0001" ;
      private string sGXsfl_303_fel_idx="0001" ;
      private string edtavRemovedetail_gximage ;
      private string edtavSelectthis_gximage ;
      private string GXt_char5 ;
      private string edtavCtladdimage_Internalname ;
      private string edtavCtldeleteimage_Internalname ;
      private string edtavCtlmodifyimage_Internalname ;
      private string edtavCtlpaidimage_Internalname ;
      private string subGridpurchaseordersfiltered_Class ;
      private string subGridpurchaseordersfiltered_Linesclass ;
      private string edtavEdit_gximage ;
      private string sImgUrl ;
      private string edtavCancel_gximage ;
      private string edtavRegister_gximage ;
      private string edtavCtladdimage_gximage ;
      private string edtavCtladdimage_Jsonclick ;
      private string edtavCtldeleteimage_gximage ;
      private string edtavCtldeleteimage_Jsonclick ;
      private string edtavCtlmodifyimage_gximage ;
      private string edtavCtlmodifyimage_Jsonclick ;
      private string edtavCtlpaidimage_gximage ;
      private string edtavCtlpaidimage_Jsonclick ;
      private string ROClassString ;
      private string edtavCtlpurchaseorderid_Jsonclick ;
      private string edtavCtlcreateddate_Jsonclick ;
      private string edtavCtlpurchaseorderconfirmateddate_Jsonclick ;
      private string edtavCtlcloseddate_Jsonclick ;
      private string edtavCtlsuppliername_Jsonclick ;
      private string edtavCtldetailslink_Jsonclick ;
      private string edtavCtlsdtvoucherlink_Jsonclick ;
      private string edtavCtlquantityreceived_Internalname ;
      private string edtavCtlnewcostprice_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string divGrid1table_Internalname ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlcurrentstock_Jsonclick ;
      private string edtavCtlquantityordered_Jsonclick ;
      private string edtavCtlquantityreceived_Jsonclick ;
      private string edtavCtlquantityreceived1_Jsonclick ;
      private string edtavCtlnewcostprice_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string edtavCtlquantityordered1_Internalname ;
      private string subFgridedit_Class ;
      private string subFgridedit_Linesclass ;
      private string divGrid1table1_Internalname ;
      private string edtavRemovedetail_Jsonclick ;
      private string edtavCtlcode1_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlcurrentstock1_Jsonclick ;
      private string edtavCtlminiumstock1_Jsonclick ;
      private string edtavCtlquantityordered1_Jsonclick ;
      private string subFgridposiblenewdetails_Class ;
      private string subFgridposiblenewdetails_Linesclass ;
      private string divGrid2table_Internalname ;
      private string edtavSelectthis_Jsonclick ;
      private string edtavCtlcode3_Jsonclick ;
      private string edtavCtlname3_Jsonclick ;
      private string edtavCtlcurrentstock3_Jsonclick ;
      private string edtavCtlminiumstock3_Jsonclick ;
      private string subFgridcancel_Class ;
      private string subFgridcancel_Linesclass ;
      private string divGrid1table2_Internalname ;
      private string edtavCtlcode2_Jsonclick ;
      private string edtavCtlname2_Jsonclick ;
      private string edtavCtlcurrentstock2_Jsonclick ;
      private string edtavCtlminiumstock2_Jsonclick ;
      private string edtavCtlquantityordered2_Jsonclick ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string edtavCtlcode4_Jsonclick ;
      private string edtavCtlname4_Jsonclick ;
      private string edtavCtlquantityordered3_Jsonclick ;
      private string edtavCtlproductcostprice_Jsonclick ;
      private string edtavCtlquantityreceived2_Jsonclick ;
      private string edtavCtlnewcostprice1_Jsonclick ;
      private string subGridpurchaseordersfiltered_Header ;
      private string subGrid1_Header ;
      private string subFgridedit_Header ;
      private string subFgridposiblenewdetails_Header ;
      private string subFgridcancel_Header ;
      private string subGrid2_Header ;
      private DateTime AV26FromDate ;
      private DateTime AV27ToDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime AV87EmailCreatedDate ;
      private DateTime AV89EmailRegisteredDate ;
      private DateTime AV93EmailModifiedDate ;
      private DateTime AV94EmailCanceledDate ;
      private DateTime AV105EmailPaidDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV53Descending ;
      private bool AV99IsOwed ;
      private bool AV54AllOk ;
      private bool AV71ControlPassed ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_161_Refreshing=false ;
      private bool bGXsfl_208_Refreshing=false ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_101_Refreshing=false ;
      private bool bGXsfl_263_Refreshing=false ;
      private bool bGXsfl_303_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV101 ;
      private bool gx_BV161 ;
      private bool gx_BV263 ;
      private bool GXt_boolean1 ;
      private bool gx_BV303 ;
      private bool gx_BV208 ;
      private bool gx_BV41 ;
      private bool AV79HasEmail ;
      private bool n8SupplierEmail ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool AV57Edit_IsBlob ;
      private bool AV56Cancel_IsBlob ;
      private bool AV49Register_IsBlob ;
      private bool AV62RemoveDetail_IsBlob ;
      private bool AV66SelectThis_IsBlob ;
      private string A8SupplierEmail ;
      private string A5SupplierName ;
      private string AV76EmailBody ;
      private string AV91EmailSupplierEmail ;
      private string AV70PurchaseOrderCanceledDescription ;
      private string AV162Removedetail_GXI ;
      private string AV163Selectthis_GXI ;
      private string AV169Edit_GXI ;
      private string AV168Cancel_GXI ;
      private string AV170Register_GXI ;
      private string AV86EmailSupplierName ;
      private string AV74EmailTitle ;
      private string AV75EmailSubtitle ;
      private string AV77EmailBodyAux ;
      private string AV62RemoveDetail ;
      private string AV66SelectThis ;
      private string AV57Edit ;
      private string AV56Cancel ;
      private string AV49Register ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridpurchaseordersfilteredContainer ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid FgrideditContainer ;
      private GXWebGrid FgridposiblenewdetailsContainer ;
      private GXWebGrid FgridcancelContainer ;
      private GXWebGrid Grid2Container ;
      private GXWebRow GridpurchaseordersfilteredRow ;
      private GXWebRow Grid2Row ;
      private GXWebRow FgridcancelRow ;
      private GXWebRow FgridposiblenewdetailsRow ;
      private GXWebRow FgrideditRow ;
      private GXWebRow Grid1Row ;
      private GXWebColumn GridpurchaseordersfilteredColumn ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn FgrideditColumn ;
      private GXWebColumn FgridposiblenewdetailsColumn ;
      private GXWebColumn FgridcancelColumn ;
      private GXWebColumn Grid2Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox cmbavOrderby ;
      private GXCheckbox chkavDescending ;
      private GXCheckbox chkavIsowed ;
      private IDataStoreProvider pr_default ;
      private int[] H00222_A4SupplierId ;
      private string[] H00222_A5SupplierName ;
      private int[] H00223_A4SupplierId ;
      private int[] H00223_A50PurchaseOrderId ;
      private string[] H00223_A8SupplierEmail ;
      private bool[] H00223_n8SupplierEmail ;
      private string[] H00223_A5SupplierName ;
      private DateTime[] H00223_A52PurchaseOrderCreatedDate ;
      private decimal[] H00223_A78PurchaseOrderTotalPaid ;
      private bool[] H00223_n78PurchaseOrderTotalPaid ;
      private int[] H00224_A4SupplierId ;
      private int[] H00224_A50PurchaseOrderId ;
      private string[] H00224_A8SupplierEmail ;
      private bool[] H00224_n8SupplierEmail ;
      private string[] H00224_A5SupplierName ;
      private int[] H00225_A4SupplierId ;
      private int[] H00225_A50PurchaseOrderId ;
      private string[] H00225_A8SupplierEmail ;
      private bool[] H00225_n8SupplierEmail ;
      private string[] H00225_A5SupplierName ;
      private DateTime[] H00225_A52PurchaseOrderCreatedDate ;
      private int[] H00226_A4SupplierId ;
      private int[] H00226_A50PurchaseOrderId ;
      private string[] H00226_A8SupplierEmail ;
      private bool[] H00226_n8SupplierEmail ;
      private string[] H00226_A5SupplierName ;
      private DateTime[] H00226_A52PurchaseOrderCreatedDate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV68WebSession ;
      private GxSimpleCollection<string> AV72URLs ;
      private GxSimpleCollection<string> AV73NamesOfAttachs ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV61DetailsRegister ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV59DetailsEdit ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV65PosiblesNewDetails ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV60DetailsCancel ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV101DetailsPay ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> GXt_objcol_SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem2 ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> AV46SDTPurchaseOrderGenerateList ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> GXt_objcol_SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem4 ;
      private GXWebForm Form ;
      private GXWindow AV48window ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV67Context ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV40OneDetail ;
      private SdtPurchaseOrder AV12Order ;
      private SdtPurchaseOrder AV103PurchaseOrder ;
   }

   public class wpmanagepurchase__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00222;
          prmH00222 = new Object[] {
          };
          Object[] prmH00223;
          prmH00223 = new Object[] {
          new ParDef("@AV55PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH00224;
          prmH00224 = new Object[] {
          new ParDef("@AV55PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH00225;
          prmH00225 = new Object[] {
          new ParDef("@AV55PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH00226;
          prmH00226 = new Object[] {
          new ParDef("@AV55PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00222", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00222,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00223", "SELECT TOP 1 T1.[SupplierId], T1.[PurchaseOrderId], T2.[SupplierEmail], T2.[SupplierName], T1.[PurchaseOrderCreatedDate], T1.[PurchaseOrderTotalPaid] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @AV55PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00223,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00224", "SELECT TOP 1 T1.[SupplierId], T1.[PurchaseOrderId], T2.[SupplierEmail], T2.[SupplierName] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @AV55PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00224,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00225", "SELECT TOP 1 T1.[SupplierId], T1.[PurchaseOrderId], T2.[SupplierEmail], T2.[SupplierName], T1.[PurchaseOrderCreatedDate] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @AV55PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00225,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H00226", "SELECT TOP 1 T1.[SupplierId], T1.[PurchaseOrderId], T2.[SupplierEmail], T2.[SupplierName], T1.[PurchaseOrderCreatedDate] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @AV55PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00226,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                return;
       }
    }

 }

}
