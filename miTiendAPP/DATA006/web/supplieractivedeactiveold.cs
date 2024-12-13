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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class supplieractivedeactiveold : GXProcedure
   {
      public supplieractivedeactiveold( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public supplieractivedeactiveold( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId ,
                           bool aP1_Active ,
                           out bool aP2_AllOk ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages )
      {
         this.AV2SupplierId = aP0_SupplierId;
         this.AV3Active = aP1_Active;
         this.AV4AllOk = false ;
         this.AV5ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_AllOk=this.AV4AllOk;
         aP3_ErrorMessages=this.AV5ErrorMessages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_SupplierId ,
                                                                             bool aP1_Active ,
                                                                             out bool aP2_AllOk )
      {
         execute(aP0_SupplierId, aP1_Active, out aP2_AllOk, out aP3_ErrorMessages);
         return AV5ErrorMessages ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 bool aP1_Active ,
                                 out bool aP2_AllOk ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages )
      {
         supplieractivedeactiveold objsupplieractivedeactiveold;
         objsupplieractivedeactiveold = new supplieractivedeactiveold();
         objsupplieractivedeactiveold.AV2SupplierId = aP0_SupplierId;
         objsupplieractivedeactiveold.AV3Active = aP1_Active;
         objsupplieractivedeactiveold.AV4AllOk = false ;
         objsupplieractivedeactiveold.AV5ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objsupplieractivedeactiveold.context.SetSubmitInitialConfig(context);
         objsupplieractivedeactiveold.initialize();
         Submit( executePrivateCatch,objsupplieractivedeactiveold);
         aP2_AllOk=this.AV4AllOk;
         aP3_ErrorMessages=this.AV5ErrorMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((supplieractivedeactiveold)stateInfo).executePrivate();
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
         args = new Object[] {(int)AV2SupplierId,(bool)AV3Active,(bool)AV4AllOk,(GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)AV5ErrorMessages} ;
         ClassLoader.Execute("asupplieractivedeactiveold","GeneXus.Programs","asupplieractivedeactiveold", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
            AV4AllOk = (bool)(args[2]) ;
            AV5ErrorMessages = (GXBaseCollection<GeneXus.Utils.SdtMessages_Message>)(args[3]) ;
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
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV5ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV2SupplierId ;
      private bool AV3Active ;
      private bool AV4AllOk ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private bool aP2_AllOk ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV5ErrorMessages ;
   }

}
