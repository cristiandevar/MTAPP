using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general.ui {
   public class sidebaritemsdp : GXProcedure
   {
      public sidebaritemsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public sidebaritemsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         sidebaritemsdp objsidebaritemsdp;
         objsidebaritemsdp = new sidebaritemsdp();
         objsidebaritemsdp.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         objsidebaritemsdp.context.SetSubmitInitialConfig(context);
         objsidebaritemsdp.initialize();
         Submit( executePrivateCatch,objsidebaritemsdp);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sidebaritemsdp)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Upgrades for Version1", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtProgramNames_ProgramName1 = AV5wwProgramNames;
         new GeneXus.Programs.general.ui.listprograms(context ).execute( out  GXt_objcol_SdtProgramNames_ProgramName1) ;
         AV5wwProgramNames = GXt_objcol_SdtProgramNames_ProgramName1;
         AV15GXV1 = 1;
         while ( AV15GXV1 <= AV5wwProgramNames.Count )
         {
            AV6wwProgramName = ((GeneXus.Programs.general.ui.SdtProgramNames_ProgramName)AV5wwProgramNames.Item(AV15GXV1));
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = AV6wwProgramName.gxTpr_Name;
            Gxm1sidebaritems.gxTpr_Title = AV6wwProgramName.gxTpr_Description;
            Gxm1sidebaritems.gxTpr_Target = AV6wwProgramName.gxTpr_Link;
            Gxm1sidebaritems.gxTpr_Hassubitems = false;
            AV15GXV1 = (int)(AV15GXV1+1);
         }
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm2rootcol.Add(Gxm1sidebaritems, 0);
         Gxm1sidebaritems.gxTpr_Id = "SubmenuHome";
         Gxm1sidebaritems.gxTpr_Title = "Home";
         Gxm1sidebaritems.gxTpr_Target = formatLink("wphome.aspx") ;
         Gxm1sidebaritems.gxTpr_Hassubitems = false;
         if ( new haspermission(context).executeUdp(  "menu invoice") )
         {
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = "SubmenuSales";
            Gxm1sidebaritems.gxTpr_Title = "Sales";
            Gxm1sidebaritems.gxTpr_Hassubitems = true;
            if ( new haspermission(context).executeUdp(  "invoice register") && new haspermission(context).executeUdp(  "product update") && new haspermission(context).executeUdp(  "product view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WPRegisterSale";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Register Sale";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpregistersale.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "invoice view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWInvoice";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Sales";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwinvoice.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "payment view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWPaymentMethod";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Payment Methods";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwpaymentmethod.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
         }
         if ( new haspermission(context).executeUdp(  "menu purchaseorder") )
         {
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = "SubmenuPurchases";
            Gxm1sidebaritems.gxTpr_Title = "Purchases";
            Gxm1sidebaritems.gxTpr_Hassubitems = true;
            if ( new haspermission(context).executeUdp(  "purchaseorder generate") && new haspermission(context).executeUdp(  "product view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WPGeneratePurchase";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Generate Order";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpgeneratepurchase.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "purchaseorder manage") && new haspermission(context).executeUdp(  "purchaseorder update") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WPManagePurchase";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Manage Order";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpmanagepurchase.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "purchaseorder view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWPurchaseOrder";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Purchase Orders";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwpurchaseorder.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
         }
         if ( new haspermission(context).executeUdp(  "menu product") )
         {
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = "SubmenuProducts";
            Gxm1sidebaritems.gxTpr_Title = "Products";
            Gxm1sidebaritems.gxTpr_Hassubitems = true;
            if ( new haspermission(context).executeUdp(  "product view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWProduct";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "All Products";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwproduct.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "product search") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WPSearchProducts";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Search";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpsearchproducts.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "product price update") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "UpdProductsCostPrice";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Update Cost Price";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpupdatecostprice.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "product retail update") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "UpdProductsRetailProfit";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Update Retail Profit";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpupdateretailprofit.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "product wholesale update") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "UpdProductsWholesaleProfit";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Update Wholesale Profit";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpupdatewholesaleprofit.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
         }
         if ( new haspermission(context).executeUdp(  "menu statistic") )
         {
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = "SubmenuStatistics";
            Gxm1sidebaritems.gxTpr_Title = "Statistics";
            Gxm1sidebaritems.gxTpr_Hassubitems = true;
            if ( new haspermission(context).executeUdp(  "statistics graphs") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WPStatisticsGraphs";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Graphics";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpstatisticsgraphs.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "statistics ranking") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WPRanking";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Rankings";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wprankings.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
         }
         if ( new haspermission(context).executeUdp(  "menu admin") )
         {
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = "SubmenuAdministration";
            Gxm1sidebaritems.gxTpr_Title = "Administration";
            Gxm1sidebaritems.gxTpr_Hassubitems = true;
            if ( new haspermission(context).executeUdp(  "user view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWUser";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Users";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwuser.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "role view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWRole";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Roles";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwrole.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "permission view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWPermissions";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Permission";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwpermission.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "brand view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWBrand";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Brands";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwbrand.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "sector view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWSector";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Sectors";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwsector.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "supplier view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWSupplier";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Suppliers";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwsupplier.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
            if ( new haspermission(context).executeUdp(  "movement view") )
            {
               Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
               Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWMovement";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Movements";
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wwmovement.aspx") ;
               Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            }
         }
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm2rootcol.Add(Gxm1sidebaritems, 0);
         Gxm1sidebaritems.gxTpr_Id = "SubmenuPerfil";
         Gxm1sidebaritems.gxTpr_Title = "Perfil";
         Gxm1sidebaritems.gxTpr_Hassubitems = true;
         AV8Context.FromXml(AV7WebSession.Get("Context"), null, "", "");
         AV9UserId = AV8Context.gxTpr_Userid;
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWMyPerfil";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "My Perfil";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("user.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim("DSP")),GXUtil.UrlEncode(StringUtil.LTrimStr(AV9UserId,6,0))}, new string[] {"Mode","UserId"}) ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         if ( new haspermission(context).executeUdp(  "perfil update") )
         {
            Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
            Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWEditPerfil";
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Edit Perfil";
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("user.aspx", new object[] {GXUtil.UrlEncode(StringUtil.RTrim("UPD")),GXUtil.UrlEncode(StringUtil.LTrimStr(AV9UserId,6,0))}, new string[] {"Mode","UserId"}) ;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         }
         if ( new haspermission(context).executeUdp(  "password update") )
         {
            Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
            Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWChangePass";
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Change Password";
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wpperfilchangepassword.aspx") ;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         }
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = "WWLogout";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = "Logout";
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = formatLink("wplogin.aspx") ;
         Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV5wwProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "mtaKB");
         GXt_objcol_SdtProgramNames_ProgramName1 = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "mtaKB");
         AV6wwProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         AV8Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV7WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV15GXV1 ;
      private int AV9UserId ;
      private IGxSession AV7WebSession ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV5wwProgramNames ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> GXt_objcol_SdtProgramNames_ProgramName1 ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> Gxm2rootcol ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV8Context ;
      private GeneXus.Programs.general.ui.SdtProgramNames_ProgramName AV6wwProgramName ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem Gxm1sidebaritems ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem Gxm3sidebaritems_sidebarsubitems ;
   }

}
