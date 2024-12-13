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
   public class getcontext : GXProcedure
   {
      public getcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public getcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context ,
                           ref bool aP1_AllOk )
      {
         this.AV8Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context) ;
         this.AV13AllOk = aP1_AllOk;
         initialize();
         executePrivate();
         aP0_Context=this.AV8Context;
         aP1_AllOk=this.AV13AllOk;
      }

      public bool executeUdp( out GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context )
      {
         execute(out aP0_Context, ref aP1_AllOk);
         return AV13AllOk ;
      }

      public void executeSubmit( out GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context ,
                                 ref bool aP1_AllOk )
      {
         getcontext objgetcontext;
         objgetcontext = new getcontext();
         objgetcontext.AV8Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context) ;
         objgetcontext.AV13AllOk = aP1_AllOk;
         objgetcontext.context.SetSubmitInitialConfig(context);
         objgetcontext.initialize();
         Submit( executePrivateCatch,objgetcontext);
         aP0_Context=this.AV8Context;
         aP1_AllOk=this.AV13AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getcontext)stateInfo).executePrivate();
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV12WebSession.Get("Context"))) || ( StringUtil.StrCmp(AV12WebSession.Get("Context"), "") == 0 ) ) )
         {
            AV13AllOk = true;
            AV8Context.FromXml(AV12WebSession.Get("Context"), null, "", "");
         }
         else
         {
            AV13AllOk = false;
            AV8Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
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
         AV12WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV13AllOk ;
      private IGxSession AV12WebSession ;
      private bool aP1_AllOk ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession aP0_Context ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV8Context ;
   }

}
