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
   public class checkauthentication : GXProcedure
   {
      public checkauthentication( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public checkauthentication( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context )
      {
         this.AV8Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context) ;
         initialize();
         executePrivate();
         aP0_Context=this.AV8Context;
      }

      public GeneXus.Programs.general.ui.SdtSDTContextSession executeUdp( )
      {
         execute(out aP0_Context);
         return AV8Context ;
      }

      public void executeSubmit( out GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context )
      {
         checkauthentication objcheckauthentication;
         objcheckauthentication = new checkauthentication();
         objcheckauthentication.AV8Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context) ;
         objcheckauthentication.context.SetSubmitInitialConfig(context);
         objcheckauthentication.initialize();
         Submit( executePrivateCatch,objcheckauthentication);
         aP0_Context=this.AV8Context;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((checkauthentication)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV8Context, ref  AV9AllOk) ;
         if ( ! AV9AllOk )
         {
            AV10WebSession.Set("SecLogIn", "Error");
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
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
         AV8Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV10WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV9AllOk ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context ;
      private IGxSession AV10WebSession ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV8Context ;
   }

}
