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
namespace GeneXus.Programs.general.ui {
   public class masterunanimosidebar : GXMasterPage
   {
      public masterunanimosidebar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public masterunanimosidebar( IGxContext context )
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
            PA012( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS012( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE012( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vSIDEBARITEMS_MPAGE", AV5sidebarItems);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSIDEBARITEMS_MPAGE", AV5sidebarItems);
         }
         GxWebStd.gx_hidden_field( context, "vTARGET_MPAGE", AV6target);
         GxWebStd.gx_hidden_field( context, "SIDEBARMENU_MPAGE_Title", StringUtil.RTrim( Sidebarmenu_Title));
         GxWebStd.gx_hidden_field( context, "SIDEBARMENU_MPAGE_Distancetotop", StringUtil.LTrim( StringUtil.NToC( (decimal)(Sidebarmenu_Distancetotop), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SIDEBARMENU_MPAGE_Selecteditemtarget", StringUtil.RTrim( Sidebarmenu_Selecteditemtarget));
         GxWebStd.gx_hidden_field( context, "SIDEBARMENU_MPAGE_Iscollapsed", StringUtil.BoolToStr( Sidebarmenu_Iscollapsed));
      }

      protected void RenderHtmlCloseForm012( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.AddJavascriptSource("Unanimo_chameleon/chameleon.js", "", false, true);
         context.AddJavascriptSource("UserControls/GeneXusUnanimo.SidebarRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCProbamosLoaderRender.js", "", false, true);
         context.AddJavascriptSource("general/ui/masterunanimosidebar.js", "?202412714404560", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "General.UI.MasterUnanimoSidebar" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Unanimo Sidebar" ;
      }

      protected void WB010( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "MainContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHeader_Internalname, 1, 0, "px", 0, "px", "HeaderContainer ContainerFluid", "left", "top", " "+"data-gx-flex"+" ", "align-items:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 24, "px", "", "left", "top", " "+"classref"+" ", "align-self:center;", "div");
            /* Static images/pictures */
            ClassString = "sidebar__toggle-ico" + " " + ((StringUtil.StrCmp(imgImage2_gximage, "")==0) ? "GX_Image_GeneXusUnanimo_list_view_white_Class" : "GX_Image_"+imgImage2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "ef73725b-c186-4f57-94bc-867e0a183c3e", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_General\\UI\\MasterUnanimoSidebar.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"classref"+" ", "min-height:20;", "div");
            /* Static images/pictures */
            ClassString = "header__logo" + " " + ((StringUtil.StrCmp(imgImage1_gximage, "")==0) ? "GX_Image_GeneXusUnanimo_genexus_logo_Class" : "GX_Image_"+imgImage1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "194a18de-81a7-4ab6-8eb3-5191aa65f696", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, imgImage1_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_General\\UI\\MasterUnanimoSidebar.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "Center", "top", " "+"classref"+" ", "flex-grow:1;min-height:20;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblApplicationheader_Internalname, "miTiendAPP", "", "", lblApplicationheader_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "header__title", 0, "", 1, 1, 0, 0, "HLP_General\\UI\\MasterUnanimoSidebar.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesidebarcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucSidebarmenu.SetProperty("Title", Sidebarmenu_Title);
            ucSidebarmenu.SetProperty("SidebarItems", AV5sidebarItems);
            ucSidebarmenu.Render(context, "genexusunanimo.sidebar", Sidebarmenu_Internalname, "SIDEBARMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContent_Internalname, 1, 0, "px", 0, "px", divContent_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUcprobamosloader1.Render(context, "ucprobamosloader", Ucprobamosloader1_Internalname, "UCPROBAMOSLOADER1_MPAGEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START012( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP010( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS012( )
      {
         START012( ) ;
         EVT012( ) ;
      }

      protected void EVT012( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
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
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE012( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm012( ) ;
            }
         }
      }

      protected void PA012( )
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
         RF012( ) ;
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

      protected void RF012( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E11012 ();
            WB010( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes012( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP010( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12012 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSIDEBARITEMS_MPAGE"), AV5sidebarItems);
            /* Read saved values. */
            AV6target = cgiGet( "vTARGET_MPAGE");
            Sidebarmenu_Title = cgiGet( "SIDEBARMENU_MPAGE_Title");
            Sidebarmenu_Distancetotop = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SIDEBARMENU_MPAGE_Distancetotop"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E11012( )
      {
         /* Load Routine */
         returnInSub = false;
         Sidebarmenu_Title = "Menu";
         ucSidebarmenu.SendProperty(context, "", true, Sidebarmenu_Internalname, "Title", Sidebarmenu_Title);
         Sidebarmenu_Distancetotop = 60;
         ucSidebarmenu.SendProperty(context, "", true, Sidebarmenu_Internalname, "DistanceToTop", StringUtil.LTrimStr( (decimal)(Sidebarmenu_Distancetotop), 9, 0));
         GXt_objcol_SdtSidebarItems_SidebarItem1 = AV5sidebarItems;
         new GeneXus.Programs.general.ui.sidebaritemsdp(context ).execute( out  GXt_objcol_SdtSidebarItems_SidebarItem1) ;
         AV5sidebarItems = GXt_objcol_SdtSidebarItems_SidebarItem1;
         AV12Pos1 = 1;
         while ( AV12Pos1 <= AV5sidebarItems.Count )
         {
            if ( ((GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem)AV5sidebarItems.Item(AV12Pos1)).gxTpr_Hassubitems )
            {
               AV13Pos2 = 1;
               while ( AV13Pos2 <= ((GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem)AV5sidebarItems.Item(AV12Pos1)).gxTpr_Sidebarsubitems.Count )
               {
                  if ( ((GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem)((GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem)AV5sidebarItems.Item(AV12Pos1)).gxTpr_Sidebarsubitems.Item(AV13Pos2)).gxTpr_Hassubitems )
                  {
                     AV14Pos3 = 1;
                     while ( AV14Pos3 <= ((GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem)((GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem)AV5sidebarItems.Item(AV12Pos1)).gxTpr_Sidebarsubitems.Item(AV13Pos2)).gxTpr_Sidebarsubsubitems.Count )
                     {
                        AV14Pos3 = (short)(AV14Pos3+1);
                     }
                  }
                  AV13Pos2 = (short)(AV13Pos2+1);
               }
            }
            AV12Pos1 = (short)(AV12Pos1+1);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12012 ();
         if (returnInSub) return;
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
         imgImage1_Link = formatLink("wphome.aspx") ;
         AssignProp("", true, imgImage1_Internalname, "Link", imgImage1_Link, true);
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
         PA012( ) ;
         WS012( ) ;
         WE012( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Unanimo_chameleon/chameleon.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?202412714404573", true, true);
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
         context.AddJavascriptSource("general/ui/masterunanimosidebar.js", "?202412714404573", false, true);
         context.AddJavascriptSource("Unanimo_chameleon/chameleon.js", "", false, true);
         context.AddJavascriptSource("UserControls/GeneXusUnanimo.SidebarRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UCProbamosLoaderRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgImage2_Internalname = "IMAGE2_MPAGE";
         imgImage1_Internalname = "IMAGE1_MPAGE";
         lblApplicationheader_Internalname = "APPLICATIONHEADER_MPAGE";
         divHeader_Internalname = "HEADER_MPAGE";
         Sidebarmenu_Internalname = "SIDEBARMENU_MPAGE";
         divTablesidebarcontainer_Internalname = "TABLESIDEBARCONTAINER_MPAGE";
         divContent_Internalname = "CONTENT_MPAGE";
         Ucprobamosloader1_Internalname = "UCPROBAMOSLOADER1_MPAGE";
         divMaintable_Internalname = "MAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         divContent_Class = "expandible-container";
         imgImage1_Link = "";
         Sidebarmenu_Iscollapsed = Convert.ToBoolean( 0);
         Sidebarmenu_Selecteditemtarget = "";
         Sidebarmenu_Distancetotop = 0;
         Sidebarmenu_Title = "";
         Contentholder.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[]}");
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
         Contentholder = new GXDataAreaControl();
         GXKey = "";
         AV5sidebarItems = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo");
         AV6target = "";
         sPrefix = "";
         ClassString = "";
         imgImage2_gximage = "";
         StyleString = "";
         sImgUrl = "";
         imgImage1_gximage = "";
         lblApplicationheader_Jsonclick = "";
         ucSidebarmenu = new GXUserControl();
         ucUcprobamosloader1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_objcol_SdtSidebarItems_SidebarItem1 = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV12Pos1 ;
      private short AV13Pos2 ;
      private short AV14Pos3 ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int Sidebarmenu_Distancetotop ;
      private int idxLst ;
      private string Sidebarmenu_Selecteditemtarget ;
      private string GXKey ;
      private string Sidebarmenu_Title ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divHeader_Internalname ;
      private string ClassString ;
      private string imgImage2_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage2_Internalname ;
      private string imgImage1_gximage ;
      private string imgImage1_Internalname ;
      private string imgImage1_Link ;
      private string lblApplicationheader_Internalname ;
      private string lblApplicationheader_Jsonclick ;
      private string divTablesidebarcontainer_Internalname ;
      private string Sidebarmenu_Internalname ;
      private string divContent_Internalname ;
      private string divContent_Class ;
      private string Ucprobamosloader1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sDynURL ;
      private bool Sidebarmenu_Iscollapsed ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV6target ;
      private GXUserControl ucSidebarmenu ;
      private GXUserControl ucUcprobamosloader1 ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> AV5sidebarItems ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> GXt_objcol_SdtSidebarItems_SidebarItem1 ;
      private GXWebForm Form ;
   }

}
