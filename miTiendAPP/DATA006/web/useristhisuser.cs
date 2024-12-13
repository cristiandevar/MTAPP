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
   public class useristhisuser : GXProcedure
   {
      public useristhisuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public useristhisuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_UserId ,
                           out bool aP1_IsThis )
      {
         this.AV8UserId = aP0_UserId;
         this.AV9IsThis = false ;
         initialize();
         executePrivate();
         aP1_IsThis=this.AV9IsThis;
      }

      public bool executeUdp( int aP0_UserId )
      {
         execute(aP0_UserId, out aP1_IsThis);
         return AV9IsThis ;
      }

      public void executeSubmit( int aP0_UserId ,
                                 out bool aP1_IsThis )
      {
         useristhisuser objuseristhisuser;
         objuseristhisuser = new useristhisuser();
         objuseristhisuser.AV8UserId = aP0_UserId;
         objuseristhisuser.AV9IsThis = false ;
         objuseristhisuser.context.SetSubmitInitialConfig(context);
         objuseristhisuser.initialize();
         Submit( executePrivateCatch,objuseristhisuser);
         aP1_IsThis=this.AV9IsThis;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((useristhisuser)stateInfo).executePrivate();
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
         AV11Context.FromXml(AV10WebSession.Get("Context"), null, "", "");
         AV9IsThis = ((AV8UserId==AV11Context.gxTpr_Userid) ? true : false);
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
         AV11Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV10WebSession = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8UserId ;
      private bool AV9IsThis ;
      private IGxSession AV10WebSession ;
      private bool aP1_IsThis ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV11Context ;
   }

}
