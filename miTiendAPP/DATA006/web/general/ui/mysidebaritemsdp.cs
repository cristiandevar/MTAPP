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
   public class mysidebaritemsdp : GXProcedure
   {
      public mysidebaritemsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public mysidebaritemsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtMySidebarItems_MySidebarItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtMySidebarItems_MySidebarItem>( context, "MySidebarItem", "GeneXusUnanimo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtMySidebarItems_MySidebarItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtMySidebarItems_MySidebarItem> aP0_Gxm2rootcol )
      {
         mysidebaritemsdp objmysidebaritemsdp;
         objmysidebaritemsdp = new mysidebaritemsdp();
         objmysidebaritemsdp.Gxm2rootcol = new GXBaseCollection<SdtMySidebarItems_MySidebarItem>( context, "MySidebarItem", "GeneXusUnanimo") ;
         objmysidebaritemsdp.context.SetSubmitInitialConfig(context);
         objmysidebaritemsdp.initialize();
         Submit( executePrivateCatch,objmysidebaritemsdp);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((mysidebaritemsdp)stateInfo).executePrivate();
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
         Gxm1mysidebaritems = new SdtMySidebarItems_MySidebarItem(context);
         Gxm2rootcol.Add(Gxm1mysidebaritems, 0);
         Gxm1mysidebaritems.gxTpr_Id = "SubmenuSales";
         Gxm1mysidebaritems.gxTpr_Title = StringUtil.Upper( "Sales");
         Gxm1mysidebaritems.gxTpr_Hassubitems = true;
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WPRegisterSale";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = StringUtil.Upper( "Register Sale");
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wpregistersale.aspx") ;
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WWInvoice";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Sales";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wwinvoice.aspx") ;
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         Gxm1mysidebaritems = new SdtMySidebarItems_MySidebarItem(context);
         Gxm2rootcol.Add(Gxm1mysidebaritems, 0);
         Gxm1mysidebaritems.gxTpr_Id = "SubmenuPurchases";
         Gxm1mysidebaritems.gxTpr_Title = "Purchases";
         Gxm1mysidebaritems.gxTpr_Hassubitems = true;
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WPGeneratePurchase";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Generate Order";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wpgeneratepurchase.aspx") ;
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WPRegisterPurchase";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Register Order";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wpmanagepurchase.aspx") ;
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WWPurchaseOrder";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Purchase Orders";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wwpurchaseorder.aspx") ;
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         Gxm1mysidebaritems = new SdtMySidebarItems_MySidebarItem(context);
         Gxm2rootcol.Add(Gxm1mysidebaritems, 0);
         Gxm1mysidebaritems.gxTpr_Id = "SubmenuProducts";
         Gxm1mysidebaritems.gxTpr_Title = "Products";
         Gxm1mysidebaritems.gxTpr_Hassubitems = true;
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WWProduct";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "All Products";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wwproduct.aspx") ;
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WPSearchProducts";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Search";
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wpsearchproducts.aspx") ;
         Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         if ( new GeneXus.Programs.general.security.hasrole(context).executeUdp(  "boss") )
         {
            Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
            Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "SubSubmenuProducts";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Update";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = true;
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem_MySubSubItem(context);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Mysidebarsubsubitems.Add(Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems, 0);
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Id = "WPUpdateCostPrice";
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Title = "Cost Price";
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Target = formatLink("wpupdatecostprice.aspx") ;
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem_MySubSubItem(context);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Mysidebarsubsubitems.Add(Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems, 0);
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Id = "WPUpdateRetailProfit";
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Title = "Retail Profit";
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Target = formatLink("wpupdateretailprofit.aspx") ;
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem_MySubSubItem(context);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Mysidebarsubsubitems.Add(Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems, 0);
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Id = "WPUpdateWholesaleProfit";
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Title = "Wholesale Profit";
            Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems.gxTpr_Target = formatLink("wpupdatewholesaleprofit.aspx") ;
         }
         if ( new GeneXus.Programs.general.security.hasrole(context).executeUdp(  "boss") )
         {
            Gxm1mysidebaritems = new SdtMySidebarItems_MySidebarItem(context);
            Gxm2rootcol.Add(Gxm1mysidebaritems, 0);
            Gxm1mysidebaritems.gxTpr_Id = "SubmenuStatistics";
            Gxm1mysidebaritems.gxTpr_Title = "Statistics";
            Gxm1mysidebaritems.gxTpr_Hassubitems = true;
            Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
            Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WPRanking";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Rankings";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wprankings.aspx") ;
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         }
         if ( new GeneXus.Programs.general.security.hasrole(context).executeUdp(  "admin") )
         {
            Gxm1mysidebaritems = new SdtMySidebarItems_MySidebarItem(context);
            Gxm2rootcol.Add(Gxm1mysidebaritems, 0);
            Gxm1mysidebaritems.gxTpr_Id = "SubmenuAdministration";
            Gxm1mysidebaritems.gxTpr_Title = "Administration";
            Gxm1mysidebaritems.gxTpr_Hassubitems = true;
            Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
            Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WWProduct";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Products";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wwproduct.aspx") ;
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
            Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
            Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WWSupplier";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Suppliers";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wwsupplier.aspx") ;
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
            Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
            Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WWBrand";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Brands";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wwbrand.aspx") ;
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
            Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
            Gxm1mysidebaritems.gxTpr_Mysidebarsubitems.Add(Gxm3mysidebaritems_mysidebarsubitems, 0);
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Id = "WWSector";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Title = "Sectors";
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Target = formatLink("wwsector.aspx") ;
            Gxm3mysidebaritems_mysidebarsubitems.gxTpr_Hassubitems = false;
         }
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
         Gxm1mysidebaritems = new SdtMySidebarItems_MySidebarItem(context);
         Gxm3mysidebaritems_mysidebarsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem(context);
         Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems = new SdtMySidebarItems_MySidebarItem_MySubItem_MySubSubItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<SdtMySidebarItems_MySidebarItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtMySidebarItems_MySidebarItem> Gxm2rootcol ;
      private SdtMySidebarItems_MySidebarItem Gxm1mysidebaritems ;
      private SdtMySidebarItems_MySidebarItem_MySubItem Gxm3mysidebaritems_mysidebarsubitems ;
      private SdtMySidebarItems_MySidebarItem_MySubItem_MySubSubItem Gxm4mysidebaritems_mysidebarsubitems_mysidebarsubsubitems ;
   }

}
