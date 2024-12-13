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
   public class dpsupplierrankingpurchases : GXProcedure
   {
      public dpsupplierrankingpurchases( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpsupplierrankingpurchases( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem>( context, "SDTSupplierRankingPurchasesItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem> aP0_Gxm2rootcol )
      {
         dpsupplierrankingpurchases objdpsupplierrankingpurchases;
         objdpsupplierrankingpurchases = new dpsupplierrankingpurchases();
         objdpsupplierrankingpurchases.Gxm2rootcol = new GXBaseCollection<SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem>( context, "SDTSupplierRankingPurchasesItem", "mtaKB") ;
         objdpsupplierrankingpurchases.context.SetSubmitInitialConfig(context);
         objdpsupplierrankingpurchases.initialize();
         Submit( executePrivateCatch,objdpsupplierrankingpurchases);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpsupplierrankingpurchases)stateInfo).executePrivate();
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
         /* Using cursor P00023 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P00023_A4SupplierId[0];
            A5SupplierName = P00023_A5SupplierName[0];
            A40000GXC1 = P00023_A40000GXC1[0];
            n40000GXC1 = P00023_n40000GXC1[0];
            A40000GXC1 = P00023_A40000GXC1[0];
            n40000GXC1 = P00023_n40000GXC1[0];
            Gxm1sdtsupplierrankingpurchases = new SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem(context);
            Gxm2rootcol.Add(Gxm1sdtsupplierrankingpurchases, 0);
            Gxm1sdtsupplierrankingpurchases.gxTpr_Id = A4SupplierId;
            Gxm1sdtsupplierrankingpurchases.gxTpr_Name = A5SupplierName;
            Gxm1sdtsupplierrankingpurchases.gxTpr_Quantitypurchases = (short)(A40000GXC1);
            pr_default.readNext(0);
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
         scmdbuf = "";
         P00023_A4SupplierId = new int[1] ;
         P00023_A5SupplierName = new string[] {""} ;
         P00023_A40000GXC1 = new int[1] ;
         P00023_n40000GXC1 = new bool[] {false} ;
         A5SupplierName = "";
         Gxm1sdtsupplierrankingpurchases = new SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpsupplierrankingpurchases__default(),
            new Object[][] {
                new Object[] {
               P00023_A4SupplierId, P00023_A5SupplierName, P00023_A40000GXC1, P00023_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A4SupplierId ;
      private int A40000GXC1 ;
      private string scmdbuf ;
      private bool n40000GXC1 ;
      private string A5SupplierName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00023_A4SupplierId ;
      private string[] P00023_A5SupplierName ;
      private int[] P00023_A40000GXC1 ;
      private bool[] P00023_n40000GXC1 ;
      private GXBaseCollection<SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem> Gxm2rootcol ;
      private SdtSDTSupplierRankingPurchases_SDTSupplierRankingPurchasesItem Gxm1sdtsupplierrankingpurchases ;
   }

   public class dpsupplierrankingpurchases__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00023", "SELECT T1.[SupplierId], T1.[SupplierName], COALESCE( T2.[GXC1], 0) AS GXC1 FROM ([Supplier] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, T4.[SupplierId] FROM ([PurchaseOrderDetail] T3 INNER JOIN [PurchaseOrder] T4 ON T4.[PurchaseOrderId] = T3.[PurchaseOrderId]) GROUP BY T4.[SupplierId] ) T2 ON T2.[SupplierId] = T1.[SupplierId]) ORDER BY T1.[SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
