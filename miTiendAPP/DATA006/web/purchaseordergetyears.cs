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
   public class purchaseordergetyears : GXProcedure
   {
      public purchaseordergetyears( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordergetyears( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<short> aP0_Years )
      {
         this.AV8Years = new GxSimpleCollection<short>() ;
         initialize();
         executePrivate();
         aP0_Years=this.AV8Years;
      }

      public GxSimpleCollection<short> executeUdp( )
      {
         execute(out aP0_Years);
         return AV8Years ;
      }

      public void executeSubmit( out GxSimpleCollection<short> aP0_Years )
      {
         purchaseordergetyears objpurchaseordergetyears;
         objpurchaseordergetyears = new purchaseordergetyears();
         objpurchaseordergetyears.AV8Years = new GxSimpleCollection<short>() ;
         objpurchaseordergetyears.context.SetSubmitInitialConfig(context);
         objpurchaseordergetyears.initialize();
         Submit( executePrivateCatch,objpurchaseordergetyears);
         aP0_Years=this.AV8Years;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordergetyears)stateInfo).executePrivate();
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
         AV13GXLvl1 = 0;
         /* Using cursor P002W2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A66PurchaseOrderClosedDate = P002W2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P002W2_n66PurchaseOrderClosedDate[0];
            A79PurchaseOrderActive = P002W2_A79PurchaseOrderActive[0];
            A50PurchaseOrderId = P002W2_A50PurchaseOrderId[0];
            AV13GXLvl1 = 1;
            AV9Year = (short)(DateTimeUtil.Year( A66PurchaseOrderClosedDate));
            if ( AV8Years.IndexOf(AV9Year) == 0 )
            {
               AV8Years.Add(AV9Year, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl1 == 0 )
         {
            AV8Years.Clear();
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
         AV8Years = new GxSimpleCollection<short>();
         scmdbuf = "";
         P002W2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P002W2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P002W2_A79PurchaseOrderActive = new bool[] {false} ;
         P002W2_A50PurchaseOrderId = new int[1] ;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordergetyears__default(),
            new Object[][] {
                new Object[] {
               P002W2_A66PurchaseOrderClosedDate, P002W2_n66PurchaseOrderClosedDate, P002W2_A79PurchaseOrderActive, P002W2_A50PurchaseOrderId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13GXLvl1 ;
      private short AV9Year ;
      private int A50PurchaseOrderId ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool n66PurchaseOrderClosedDate ;
      private bool A79PurchaseOrderActive ;
      private GxSimpleCollection<short> AV8Years ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P002W2_A66PurchaseOrderClosedDate ;
      private bool[] P002W2_n66PurchaseOrderClosedDate ;
      private bool[] P002W2_A79PurchaseOrderActive ;
      private int[] P002W2_A50PurchaseOrderId ;
      private GxSimpleCollection<short> aP0_Years ;
   }

   public class purchaseordergetyears__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002W2;
          prmP002W2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P002W2", "SELECT [PurchaseOrderClosedDate], [PurchaseOrderActive], [PurchaseOrderId] FROM [PurchaseOrder] WHERE ([PurchaseOrderActive] = 1) AND (Not ( [PurchaseOrderClosedDate] IS NULL or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ) or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )))) ORDER BY [PurchaseOrderClosedDate] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002W2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
