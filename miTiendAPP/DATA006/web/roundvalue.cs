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
   public class roundvalue : GXProcedure
   {
      public roundvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public roundvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( decimal aP0_Value ,
                           out decimal aP1_ValueRounded )
      {
         this.AV9Value = aP0_Value;
         this.AV12ValueRounded = 0 ;
         initialize();
         executePrivate();
         aP1_ValueRounded=this.AV12ValueRounded;
      }

      public decimal executeUdp( decimal aP0_Value )
      {
         execute(aP0_Value, out aP1_ValueRounded);
         return AV12ValueRounded ;
      }

      public void executeSubmit( decimal aP0_Value ,
                                 out decimal aP1_ValueRounded )
      {
         roundvalue objroundvalue;
         objroundvalue = new roundvalue();
         objroundvalue.AV9Value = aP0_Value;
         objroundvalue.AV12ValueRounded = 0 ;
         objroundvalue.context.SetSubmitInitialConfig(context);
         objroundvalue.initialize();
         Submit( executePrivateCatch,objroundvalue);
         aP1_ValueRounded=this.AV12ValueRounded;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((roundvalue)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV15Context, ref  AV16AllOk) ;
         if ( ! AV16AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV13LessSignifDigit = 1;
         AV10Count = 0;
         AV12ValueRounded = NumberUtil.Round( AV9Value, 0);
         while ( AV10Count < AV13LessSignifDigit )
         {
            AV11Digit = (short)(((int)((AV12ValueRounded) % (10))));
            AV12ValueRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV12ValueRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
            AV10Count = (short)(AV10Count+1);
            if ( AV11Digit > 5 )
            {
               AV12ValueRounded = (decimal)(AV12ValueRounded+1);
            }
         }
         AV14I = 1;
         while ( AV14I <= AV10Count )
         {
            AV12ValueRounded = (decimal)(AV12ValueRounded*10);
            AV14I = (short)(AV14I+1);
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
         AV15Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13LessSignifDigit ;
      private short AV10Count ;
      private short AV11Digit ;
      private short AV14I ;
      private decimal AV9Value ;
      private decimal AV12ValueRounded ;
      private bool AV16AllOk ;
      private decimal aP1_ValueRounded ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV15Context ;
   }

}
