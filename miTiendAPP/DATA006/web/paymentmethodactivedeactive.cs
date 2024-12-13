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
   public class paymentmethodactivedeactive : GXProcedure
   {
      public paymentmethodactivedeactive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public paymentmethodactivedeactive( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PaymentMethodId ,
                           bool aP1_PaymentMethodActive ,
                           out bool aP2_AllOk ,
                           out string aP3_ErrorMessage )
      {
         this.AV8PaymentMethodId = aP0_PaymentMethodId;
         this.AV9PaymentMethodActive = aP1_PaymentMethodActive;
         this.AV10AllOk = false ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP2_AllOk=this.AV10AllOk;
         aP3_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( int aP0_PaymentMethodId ,
                                bool aP1_PaymentMethodActive ,
                                out bool aP2_AllOk )
      {
         execute(aP0_PaymentMethodId, aP1_PaymentMethodActive, out aP2_AllOk, out aP3_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( int aP0_PaymentMethodId ,
                                 bool aP1_PaymentMethodActive ,
                                 out bool aP2_AllOk ,
                                 out string aP3_ErrorMessage )
      {
         paymentmethodactivedeactive objpaymentmethodactivedeactive;
         objpaymentmethodactivedeactive = new paymentmethodactivedeactive();
         objpaymentmethodactivedeactive.AV8PaymentMethodId = aP0_PaymentMethodId;
         objpaymentmethodactivedeactive.AV9PaymentMethodActive = aP1_PaymentMethodActive;
         objpaymentmethodactivedeactive.AV10AllOk = false ;
         objpaymentmethodactivedeactive.AV11ErrorMessage = "" ;
         objpaymentmethodactivedeactive.context.SetSubmitInitialConfig(context);
         objpaymentmethodactivedeactive.initialize();
         Submit( executePrivateCatch,objpaymentmethodactivedeactive);
         aP2_AllOk=this.AV10AllOk;
         aP3_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paymentmethodactivedeactive)stateInfo).executePrivate();
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
         AV12PaymentMethod.Load(AV8PaymentMethodId);
         AV12PaymentMethod.gxTpr_Paymentmethodactive = AV9PaymentMethodActive;
         AV12PaymentMethod.Update();
         if ( AV12PaymentMethod.Success() )
         {
            AV10AllOk = true;
            context.CommitDataStores("paymentmethodactivedeactive",pr_default);
         }
         else
         {
            AV10AllOk = false;
            AV11ErrorMessage = AV12PaymentMethod.GetMessages().ToJSonString(false);
            context.RollbackDataStores("paymentmethodactivedeactive",pr_default);
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
         AV11ErrorMessage = "";
         AV12PaymentMethod = new SdtPaymentMethod(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paymentmethodactivedeactive__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8PaymentMethodId ;
      private bool AV9PaymentMethodActive ;
      private bool AV10AllOk ;
      private string AV11ErrorMessage ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP2_AllOk ;
      private string aP3_ErrorMessage ;
      private SdtPaymentMethod AV12PaymentMethod ;
   }

   public class paymentmethodactivedeactive__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
