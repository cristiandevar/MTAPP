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
   public class dpallproductswhereordered : GXProcedure
   {
      public dpallproductswhereordered( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpallproductswhereordered( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP0_Gxm2rootcol )
      {
         dpallproductswhereordered objdpallproductswhereordered;
         objdpallproductswhereordered = new dpallproductswhereordered();
         objdpallproductswhereordered.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         objdpallproductswhereordered.context.SetSubmitInitialConfig(context);
         objdpallproductswhereordered.initialize();
         Submit( executePrivateCatch,objdpallproductswhereordered);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpallproductswhereordered)stateInfo).executePrivate();
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
         /* Using cursor P00092 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A50PurchaseOrderId = P00092_A50PurchaseOrderId[0];
            A4SupplierId = P00092_A4SupplierId[0];
            A1BrandId = P00092_A1BrandId[0];
            n1BrandId = P00092_n1BrandId[0];
            A9SectorId = P00092_A9SectorId[0];
            n9SectorId = P00092_n9SectorId[0];
            A66PurchaseOrderClosedDate = P00092_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P00092_n66PurchaseOrderClosedDate[0];
            A79PurchaseOrderActive = P00092_A79PurchaseOrderActive[0];
            A15ProductId = P00092_A15ProductId[0];
            A55ProductCode = P00092_A55ProductCode[0];
            n55ProductCode = P00092_n55ProductCode[0];
            A16ProductName = P00092_A16ProductName[0];
            A10SectorName = P00092_A10SectorName[0];
            A5SupplierName = P00092_A5SupplierName[0];
            A2BrandName = P00092_A2BrandName[0];
            A61PurchaseOrderDetailId = P00092_A61PurchaseOrderDetailId[0];
            A4SupplierId = P00092_A4SupplierId[0];
            A66PurchaseOrderClosedDate = P00092_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P00092_n66PurchaseOrderClosedDate[0];
            A79PurchaseOrderActive = P00092_A79PurchaseOrderActive[0];
            A5SupplierName = P00092_A5SupplierName[0];
            A1BrandId = P00092_A1BrandId[0];
            n1BrandId = P00092_n1BrandId[0];
            A9SectorId = P00092_A9SectorId[0];
            n9SectorId = P00092_n9SectorId[0];
            A55ProductCode = P00092_A55ProductCode[0];
            n55ProductCode = P00092_n55ProductCode[0];
            A16ProductName = P00092_A16ProductName[0];
            A2BrandName = P00092_A2BrandName[0];
            A10SectorName = P00092_A10SectorName[0];
            Gxm1sdtproductsselected = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            Gxm2rootcol.Add(Gxm1sdtproductsselected, 0);
            Gxm1sdtproductsselected.gxTpr_Id = A15ProductId;
            Gxm1sdtproductsselected.gxTpr_Code = A55ProductCode;
            Gxm1sdtproductsselected.gxTpr_Name = A16ProductName;
            Gxm1sdtproductsselected.gxTpr_Sector = A10SectorName;
            Gxm1sdtproductsselected.gxTpr_Supplier = A5SupplierName;
            Gxm1sdtproductsselected.gxTpr_Brand = A2BrandName;
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
         P00092_A50PurchaseOrderId = new int[1] ;
         P00092_A4SupplierId = new int[1] ;
         P00092_A1BrandId = new int[1] ;
         P00092_n1BrandId = new bool[] {false} ;
         P00092_A9SectorId = new int[1] ;
         P00092_n9SectorId = new bool[] {false} ;
         P00092_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P00092_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P00092_A79PurchaseOrderActive = new bool[] {false} ;
         P00092_A15ProductId = new int[1] ;
         P00092_A55ProductCode = new string[] {""} ;
         P00092_n55ProductCode = new bool[] {false} ;
         P00092_A16ProductName = new string[] {""} ;
         P00092_A10SectorName = new string[] {""} ;
         P00092_A5SupplierName = new string[] {""} ;
         P00092_A2BrandName = new string[] {""} ;
         P00092_A61PurchaseOrderDetailId = new int[1] ;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         A55ProductCode = "";
         A16ProductName = "";
         A10SectorName = "";
         A5SupplierName = "";
         A2BrandName = "";
         Gxm1sdtproductsselected = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpallproductswhereordered__default(),
            new Object[][] {
                new Object[] {
               P00092_A50PurchaseOrderId, P00092_A4SupplierId, P00092_A1BrandId, P00092_n1BrandId, P00092_A9SectorId, P00092_n9SectorId, P00092_A66PurchaseOrderClosedDate, P00092_n66PurchaseOrderClosedDate, P00092_A79PurchaseOrderActive, P00092_A15ProductId,
               P00092_A55ProductCode, P00092_n55ProductCode, P00092_A16ProductName, P00092_A10SectorName, P00092_A5SupplierName, P00092_A2BrandName, P00092_A61PurchaseOrderDetailId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A15ProductId ;
      private int A61PurchaseOrderDetailId ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n66PurchaseOrderClosedDate ;
      private bool A79PurchaseOrderActive ;
      private bool n55ProductCode ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A10SectorName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00092_A50PurchaseOrderId ;
      private int[] P00092_A4SupplierId ;
      private int[] P00092_A1BrandId ;
      private bool[] P00092_n1BrandId ;
      private int[] P00092_A9SectorId ;
      private bool[] P00092_n9SectorId ;
      private DateTime[] P00092_A66PurchaseOrderClosedDate ;
      private bool[] P00092_n66PurchaseOrderClosedDate ;
      private bool[] P00092_A79PurchaseOrderActive ;
      private int[] P00092_A15ProductId ;
      private string[] P00092_A55ProductCode ;
      private bool[] P00092_n55ProductCode ;
      private string[] P00092_A16ProductName ;
      private string[] P00092_A10SectorName ;
      private string[] P00092_A5SupplierName ;
      private string[] P00092_A2BrandName ;
      private int[] P00092_A61PurchaseOrderDetailId ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> Gxm2rootcol ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem Gxm1sdtproductsselected ;
   }

   public class dpallproductswhereordered__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00092;
          prmP00092 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00092", "SELECT T1.[PurchaseOrderId], T2.[SupplierId], T4.[BrandId], T4.[SectorId], T2.[PurchaseOrderClosedDate], T2.[PurchaseOrderActive], T1.[ProductId], T4.[ProductCode], T4.[ProductName], T6.[SectorName], T3.[SupplierName], T5.[BrandName], T1.[PurchaseOrderDetailId] FROM ((((([PurchaseOrderDetail] T1 INNER JOIN [PurchaseOrder] T2 ON T2.[PurchaseOrderId] = T1.[PurchaseOrderId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = T2.[SupplierId]) INNER JOIN [Product] T4 ON T4.[ProductId] = T1.[ProductId]) LEFT JOIN [Brand] T5 ON T5.[BrandId] = T4.[BrandId]) LEFT JOIN [Sector] T6 ON T6.[SectorId] = T4.[SectorId]) WHERE (T2.[PurchaseOrderActive] = 1) AND (( (T2.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T2.[PurchaseOrderClosedDate] IS NULL or T2.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ) or (T2.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )))) ORDER BY T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00092,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((string[]) buf[15])[0] = rslt.getVarchar(12);
                ((int[]) buf[16])[0] = rslt.getInt(13);
                return;
       }
    }

 }

}
