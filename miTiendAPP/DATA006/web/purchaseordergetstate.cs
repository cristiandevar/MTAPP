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
   public class purchaseordergetstate : GXProcedure
   {
      public purchaseordergetstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordergetstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           out string aP1_PurchaseOrderState )
      {
         this.AV8PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV9PurchaseOrderState = "" ;
         initialize();
         executePrivate();
         aP1_PurchaseOrderState=this.AV9PurchaseOrderState;
      }

      public string executeUdp( int aP0_PurchaseOrderId )
      {
         execute(aP0_PurchaseOrderId, out aP1_PurchaseOrderState);
         return AV9PurchaseOrderState ;
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 out string aP1_PurchaseOrderState )
      {
         purchaseordergetstate objpurchaseordergetstate;
         objpurchaseordergetstate = new purchaseordergetstate();
         objpurchaseordergetstate.AV8PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseordergetstate.AV9PurchaseOrderState = "" ;
         objpurchaseordergetstate.context.SetSubmitInitialConfig(context);
         objpurchaseordergetstate.initialize();
         Submit( executePrivateCatch,objpurchaseordergetstate);
         aP1_PurchaseOrderState=this.AV9PurchaseOrderState;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordergetstate)stateInfo).executePrivate();
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
         /* Using cursor P002H2 */
         pr_default.execute(0, new Object[] {AV8PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A50PurchaseOrderId = P002H2_A50PurchaseOrderId[0];
            A79PurchaseOrderActive = P002H2_A79PurchaseOrderActive[0];
            A66PurchaseOrderClosedDate = P002H2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P002H2_n66PurchaseOrderClosedDate[0];
            if ( ! A79PurchaseOrderActive )
            {
               AV9PurchaseOrderState = "Canceled";
            }
            else if ( A79PurchaseOrderActive && ( P002H2_n66PurchaseOrderClosedDate[0] || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
            {
               AV9PurchaseOrderState = "Pending";
            }
            else if ( A79PurchaseOrderActive && ! ( P002H2_n66PurchaseOrderClosedDate[0] || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
            {
               AV9PurchaseOrderState = "Received";
            }
            else
            {
               AV9PurchaseOrderState = "";
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         AV9PurchaseOrderState = "";
         scmdbuf = "";
         P002H2_A50PurchaseOrderId = new int[1] ;
         P002H2_A79PurchaseOrderActive = new bool[] {false} ;
         P002H2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P002H2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordergetstate__default(),
            new Object[][] {
                new Object[] {
               P002H2_A50PurchaseOrderId, P002H2_A79PurchaseOrderActive, P002H2_A66PurchaseOrderClosedDate, P002H2_n66PurchaseOrderClosedDate
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8PurchaseOrderId ;
      private int A50PurchaseOrderId ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool A79PurchaseOrderActive ;
      private bool n66PurchaseOrderClosedDate ;
      private string AV9PurchaseOrderState ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002H2_A50PurchaseOrderId ;
      private bool[] P002H2_A79PurchaseOrderActive ;
      private DateTime[] P002H2_A66PurchaseOrderClosedDate ;
      private bool[] P002H2_n66PurchaseOrderClosedDate ;
      private string aP1_PurchaseOrderState ;
   }

   public class purchaseordergetstate__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002H2;
          prmP002H2 = new Object[] {
          new ParDef("@AV8PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002H2", "SELECT [PurchaseOrderId], [PurchaseOrderActive], [PurchaseOrderClosedDate] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @AV8PurchaseOrderId ORDER BY [PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H2,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
