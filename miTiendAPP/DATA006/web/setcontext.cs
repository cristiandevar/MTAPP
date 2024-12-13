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
namespace GeneXus.Programs {
   public class setcontext : GXProcedure
   {
      public setcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public setcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context )
      {
         this.AV8Context = aP0_Context;
         initialize();
         executePrivate();
      }

      public void executeSubmit( GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context )
      {
         setcontext objsetcontext;
         objsetcontext = new setcontext();
         objsetcontext.AV8Context = aP0_Context;
         objsetcontext.context.SetSubmitInitialConfig(context);
         objsetcontext.initialize();
         Submit( executePrivateCatch,objsetcontext);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((setcontext)stateInfo).executePrivate();
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
         AV9WebSession.Set("Context", AV8Context.ToXml(false, true, "", ""));
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
         AV9WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxSession AV9WebSession ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV8Context ;
   }

}
