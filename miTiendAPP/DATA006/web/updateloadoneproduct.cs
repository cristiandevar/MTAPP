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
   public class updateloadoneproduct : GXProcedure
   {
      public updateloadoneproduct( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public updateloadoneproduct( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           out SdtSDTProductsSelected_SDTProductsSelectedItem aP1_OneProduct )
      {
         this.A15ProductId = aP0_ProductId;
         this.AV8OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context) ;
         initialize();
         executePrivate();
         aP1_OneProduct=this.AV8OneProduct;
      }

      public SdtSDTProductsSelected_SDTProductsSelectedItem executeUdp( int aP0_ProductId )
      {
         execute(aP0_ProductId, out aP1_OneProduct);
         return AV8OneProduct ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 out SdtSDTProductsSelected_SDTProductsSelectedItem aP1_OneProduct )
      {
         updateloadoneproduct objupdateloadoneproduct;
         objupdateloadoneproduct = new updateloadoneproduct();
         objupdateloadoneproduct.A15ProductId = aP0_ProductId;
         objupdateloadoneproduct.AV8OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context) ;
         objupdateloadoneproduct.context.SetSubmitInitialConfig(context);
         objupdateloadoneproduct.initialize();
         Submit( executePrivateCatch,objupdateloadoneproduct);
         aP1_OneProduct=this.AV8OneProduct;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((updateloadoneproduct)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV9Context, ref  AV10AllOk) ;
         if ( ! AV10AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV8OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         /* Using cursor P00132 */
         pr_default.execute(0, new Object[] {A15ProductId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1BrandId = P00132_A1BrandId[0];
            n1BrandId = P00132_n1BrandId[0];
            A9SectorId = P00132_A9SectorId[0];
            n9SectorId = P00132_n9SectorId[0];
            A4SupplierId = P00132_A4SupplierId[0];
            A16ProductName = P00132_A16ProductName[0];
            A55ProductCode = P00132_A55ProductCode[0];
            n55ProductCode = P00132_n55ProductCode[0];
            A5SupplierName = P00132_A5SupplierName[0];
            A2BrandName = P00132_A2BrandName[0];
            A10SectorName = P00132_A10SectorName[0];
            A87ProductWholesaleProfit = P00132_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = P00132_n87ProductWholesaleProfit[0];
            A85ProductCostPrice = P00132_A85ProductCostPrice[0];
            n85ProductCostPrice = P00132_n85ProductCostPrice[0];
            A89ProductRetailProfit = P00132_A89ProductRetailProfit[0];
            n89ProductRetailProfit = P00132_n89ProductRetailProfit[0];
            A2BrandName = P00132_A2BrandName[0];
            A10SectorName = P00132_A10SectorName[0];
            A5SupplierName = P00132_A5SupplierName[0];
            GXt_decimal1 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal1) ;
            GXt_decimal2 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
            GXt_decimal3 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal3) ;
            A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal3);
            GXt_decimal3 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
            GXt_decimal2 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal2) ;
            GXt_decimal1 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal1) ;
            A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal1);
            AV8OneProduct.gxTpr_Id = A15ProductId;
            AV8OneProduct.gxTpr_Name = A16ProductName;
            AV8OneProduct.gxTpr_Code = A55ProductCode;
            AV8OneProduct.gxTpr_Supplier = A5SupplierName;
            AV8OneProduct.gxTpr_Brand = A2BrandName;
            AV8OneProduct.gxTpr_Sector = A10SectorName;
            AV8OneProduct.gxTpr_Costprice = A85ProductCostPrice;
            AV8OneProduct.gxTpr_Newcostprice = A85ProductCostPrice;
            AV8OneProduct.gxTpr_Retailprofit = A89ProductRetailProfit;
            AV8OneProduct.gxTpr_Newretailprofit = A89ProductRetailProfit;
            AV8OneProduct.gxTpr_Retailprice = A90ProductRetailPrice;
            AV8OneProduct.gxTpr_Wholesaleprofit = A87ProductWholesaleProfit;
            AV8OneProduct.gxTpr_Newwholesaleprofit = A87ProductWholesaleProfit;
            AV8OneProduct.gxTpr_Wholesaleprice = A88ProductWholesalePrice;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         AV8OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV9Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         P00132_A1BrandId = new int[1] ;
         P00132_n1BrandId = new bool[] {false} ;
         P00132_A9SectorId = new int[1] ;
         P00132_n9SectorId = new bool[] {false} ;
         P00132_A4SupplierId = new int[1] ;
         P00132_A15ProductId = new int[1] ;
         P00132_A16ProductName = new string[] {""} ;
         P00132_A55ProductCode = new string[] {""} ;
         P00132_n55ProductCode = new bool[] {false} ;
         P00132_A5SupplierName = new string[] {""} ;
         P00132_A2BrandName = new string[] {""} ;
         P00132_A10SectorName = new string[] {""} ;
         P00132_A87ProductWholesaleProfit = new decimal[1] ;
         P00132_n87ProductWholesaleProfit = new bool[] {false} ;
         P00132_A85ProductCostPrice = new decimal[1] ;
         P00132_n85ProductCostPrice = new bool[] {false} ;
         P00132_A89ProductRetailProfit = new decimal[1] ;
         P00132_n89ProductRetailProfit = new bool[] {false} ;
         A16ProductName = "";
         A55ProductCode = "";
         A5SupplierName = "";
         A2BrandName = "";
         A10SectorName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.updateloadoneproduct__default(),
            new Object[][] {
                new Object[] {
               P00132_A1BrandId, P00132_n1BrandId, P00132_A9SectorId, P00132_n9SectorId, P00132_A4SupplierId, P00132_A15ProductId, P00132_A16ProductName, P00132_A55ProductCode, P00132_n55ProductCode, P00132_A5SupplierName,
               P00132_A2BrandName, P00132_A10SectorName, P00132_A87ProductWholesaleProfit, P00132_n87ProductWholesaleProfit, P00132_A85ProductCostPrice, P00132_n85ProductCostPrice, P00132_A89ProductRetailProfit, P00132_n89ProductRetailProfit
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A15ProductId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A4SupplierId ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private bool AV10AllOk ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n55ProductCode ;
      private bool n87ProductWholesaleProfit ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private string A16ProductName ;
      private string A55ProductCode ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00132_A1BrandId ;
      private bool[] P00132_n1BrandId ;
      private int[] P00132_A9SectorId ;
      private bool[] P00132_n9SectorId ;
      private int[] P00132_A4SupplierId ;
      private int[] P00132_A15ProductId ;
      private string[] P00132_A16ProductName ;
      private string[] P00132_A55ProductCode ;
      private bool[] P00132_n55ProductCode ;
      private string[] P00132_A5SupplierName ;
      private string[] P00132_A2BrandName ;
      private string[] P00132_A10SectorName ;
      private decimal[] P00132_A87ProductWholesaleProfit ;
      private bool[] P00132_n87ProductWholesaleProfit ;
      private decimal[] P00132_A85ProductCostPrice ;
      private bool[] P00132_n85ProductCostPrice ;
      private decimal[] P00132_A89ProductRetailProfit ;
      private bool[] P00132_n89ProductRetailProfit ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem aP1_OneProduct ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV8OneProduct ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV9Context ;
   }

   public class updateloadoneproduct__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00132;
          prmP00132 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00132", "SELECT TOP 1 T1.[BrandId], T1.[SectorId], T1.[SupplierId], T1.[ProductId], T1.[ProductName], T1.[ProductCode], T4.[SupplierName], T2.[BrandName], T3.[SectorName], T1.[ProductWholesaleProfit], T1.[ProductCostPrice], T1.[ProductRetailProfit] FROM ((([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId]) WHERE T1.[ProductId] = @ProductId ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00132,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
