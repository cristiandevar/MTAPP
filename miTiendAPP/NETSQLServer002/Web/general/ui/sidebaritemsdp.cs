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
            GXUtil.SaveToEventLog( "Design", e);
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
         AV11GXV1 = 1;
         while ( AV11GXV1 <= AV5wwProgramNames.Count )
         {
            AV6wwProgramName = ((GeneXus.Programs.general.ui.SdtProgramNames_ProgramName)AV5wwProgramNames.Item(AV11GXV1));
            Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
            Gxm2rootcol.Add(Gxm1sidebaritems, 0);
            Gxm1sidebaritems.gxTpr_Id = AV6wwProgramName.gxTpr_Name;
            Gxm1sidebaritems.gxTpr_Title = AV6wwProgramName.gxTpr_Description;
            Gxm1sidebaritems.gxTpr_Target = AV6wwProgramName.gxTpr_Link;
            Gxm1sidebaritems.gxTpr_Hassubitems = false;
            AV11GXV1 = (int)(AV11GXV1+1);
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
         AV5wwProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "mtaKB");
         GXt_objcol_SdtProgramNames_ProgramName1 = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "mtaKB");
         AV6wwProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11GXV1 ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV5wwProgramNames ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> GXt_objcol_SdtProgramNames_ProgramName1 ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> Gxm2rootcol ;
      private GeneXus.Programs.general.ui.SdtProgramNames_ProgramName AV6wwProgramName ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem Gxm1sidebaritems ;
   }

}
