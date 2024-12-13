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
   public class dpproductsrankingsale : GXProcedure
   {
      public dpproductsrankingsale( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpproductsrankingsale( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem>( context, "SDTProductsRankingSaleItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem> aP0_Gxm2rootcol )
      {
         dpproductsrankingsale objdpproductsrankingsale;
         objdpproductsrankingsale = new dpproductsrankingsale();
         objdpproductsrankingsale.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem>( context, "SDTProductsRankingSaleItem", "mtaKB") ;
         objdpproductsrankingsale.context.SetSubmitInitialConfig(context);
         objdpproductsrankingsale.initialize();
         Submit( executePrivateCatch,objdpproductsrankingsale);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpproductsrankingsale)stateInfo).executePrivate();
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
         /* Using cursor P00033 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15ProductId = P00033_A15ProductId[0];
            A16ProductName = P00033_A16ProductName[0];
            A4SupplierId = P00033_A4SupplierId[0];
            A9SectorId = P00033_A9SectorId[0];
            A40000GXC1 = P00033_A40000GXC1[0];
            n40000GXC1 = P00033_n40000GXC1[0];
            A40001GXC2 = P00033_A40001GXC2[0];
            n40001GXC2 = P00033_n40001GXC2[0];
            A40002GXC3 = P00033_A40002GXC3[0];
            n40002GXC3 = P00033_n40002GXC3[0];
            A40000GXC1 = P00033_A40000GXC1[0];
            n40000GXC1 = P00033_n40000GXC1[0];
            A40001GXC2 = P00033_A40001GXC2[0];
            n40001GXC2 = P00033_n40001GXC2[0];
            A40002GXC3 = P00033_A40002GXC3[0];
            n40002GXC3 = P00033_n40002GXC3[0];
            Gxm1sdtproductsrankingsale = new SdtSDTProductsRankingSale_SDTProductsRankingSaleItem(context);
            Gxm2rootcol.Add(Gxm1sdtproductsrankingsale, 0);
            Gxm1sdtproductsrankingsale.gxTpr_Id = A15ProductId;
            Gxm1sdtproductsrankingsale.gxTpr_Name = A16ProductName;
            Gxm1sdtproductsrankingsale.gxTpr_Quantitysales = (short)(A40000GXC1);
            Gxm1sdtproductsrankingsale.gxTpr_Quantityunitssale = (short)(A40001GXC2);
            Gxm1sdtproductsrankingsale.gxTpr_Subtotal = (decimal)(A40002GXC3);
            Gxm1sdtproductsrankingsale.gxTpr_Supplier = A4SupplierId;
            Gxm1sdtproductsrankingsale.gxTpr_Sector = A9SectorId;
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
         P00033_A15ProductId = new int[1] ;
         P00033_A16ProductName = new string[] {""} ;
         P00033_A4SupplierId = new int[1] ;
         P00033_A9SectorId = new int[1] ;
         P00033_A40000GXC1 = new int[1] ;
         P00033_n40000GXC1 = new bool[] {false} ;
         P00033_A40001GXC2 = new int[1] ;
         P00033_n40001GXC2 = new bool[] {false} ;
         P00033_A40002GXC3 = new long[1] ;
         P00033_n40002GXC3 = new bool[] {false} ;
         A16ProductName = "";
         Gxm1sdtproductsrankingsale = new SdtSDTProductsRankingSale_SDTProductsRankingSaleItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpproductsrankingsale__default(),
            new Object[][] {
                new Object[] {
               P00033_A15ProductId, P00033_A16ProductName, P00033_A4SupplierId, P00033_A9SectorId, P00033_A40000GXC1, P00033_n40000GXC1, P00033_A40001GXC2, P00033_n40001GXC2, P00033_A40002GXC3, P00033_n40002GXC3
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A15ProductId ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private long A40002GXC3 ;
      private string scmdbuf ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private string A16ProductName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00033_A15ProductId ;
      private string[] P00033_A16ProductName ;
      private int[] P00033_A4SupplierId ;
      private int[] P00033_A9SectorId ;
      private int[] P00033_A40000GXC1 ;
      private bool[] P00033_n40000GXC1 ;
      private int[] P00033_A40001GXC2 ;
      private bool[] P00033_n40001GXC2 ;
      private long[] P00033_A40002GXC3 ;
      private bool[] P00033_n40002GXC3 ;
      private GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem> Gxm2rootcol ;
      private SdtSDTProductsRankingSale_SDTProductsRankingSaleItem Gxm1sdtproductsrankingsale ;
   }

   public class dpproductsrankingsale__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00033;
          prmP00033 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00033", "SELECT T1.[ProductId], T1.[ProductName], T1.[SupplierId], T1.[SectorId], COALESCE( T2.[GXC1], 0) AS GXC1, COALESCE( T2.[GXC2], 0) AS GXC2, COALESCE( T2.[GXC3], 0) AS GXC3 FROM ([Product] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [ProductId], SUM([InvoiceDetailQuantity]) AS GXC2, SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 20, 10))) AS GXC3 FROM [InvoiceDetail] GROUP BY [ProductId] ) T2 ON T2.[ProductId] = T1.[ProductId]) ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00033,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
