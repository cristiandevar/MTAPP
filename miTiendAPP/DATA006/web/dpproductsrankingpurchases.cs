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
   public class dpproductsrankingpurchases : GXProcedure
   {
      public dpproductsrankingpurchases( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpproductsrankingpurchases( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           int aP1_SupplierId ,
                           int aP2_SectorId ,
                           int aP3_BrandId ,
                           out GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> aP4_Gxm2rootcol )
      {
         this.AV8Name = aP0_Name;
         this.AV5SupplierId = aP1_SupplierId;
         this.AV6SectorId = aP2_SectorId;
         this.AV7BrandId = aP3_BrandId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem>( context, "SDTProductsRankingPurchasesItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> executeUdp( string aP0_Name ,
                                                                                                          int aP1_SupplierId ,
                                                                                                          int aP2_SectorId ,
                                                                                                          int aP3_BrandId )
      {
         execute(aP0_Name, aP1_SupplierId, aP2_SectorId, aP3_BrandId, out aP4_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_Name ,
                                 int aP1_SupplierId ,
                                 int aP2_SectorId ,
                                 int aP3_BrandId ,
                                 out GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> aP4_Gxm2rootcol )
      {
         dpproductsrankingpurchases objdpproductsrankingpurchases;
         objdpproductsrankingpurchases = new dpproductsrankingpurchases();
         objdpproductsrankingpurchases.AV8Name = aP0_Name;
         objdpproductsrankingpurchases.AV5SupplierId = aP1_SupplierId;
         objdpproductsrankingpurchases.AV6SectorId = aP2_SectorId;
         objdpproductsrankingpurchases.AV7BrandId = aP3_BrandId;
         objdpproductsrankingpurchases.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem>( context, "SDTProductsRankingPurchasesItem", "mtaKB") ;
         objdpproductsrankingpurchases.context.SetSubmitInitialConfig(context);
         objdpproductsrankingpurchases.initialize();
         Submit( executePrivateCatch,objdpproductsrankingpurchases);
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpproductsrankingpurchases)stateInfo).executePrivate();
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8Name ,
                                              AV7BrandId ,
                                              AV6SectorId ,
                                              AV5SupplierId ,
                                              A16ProductName ,
                                              A1BrandId ,
                                              A9SectorId ,
                                              A4SupplierId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV8Name = StringUtil.Concat( StringUtil.RTrim( AV8Name), "%", "");
         /* Using cursor P00044 */
         pr_default.execute(0, new Object[] {lV8Name, AV7BrandId, AV6SectorId, AV5SupplierId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P00044_A4SupplierId[0];
            A9SectorId = P00044_A9SectorId[0];
            n9SectorId = P00044_n9SectorId[0];
            A1BrandId = P00044_A1BrandId[0];
            n1BrandId = P00044_n1BrandId[0];
            A16ProductName = P00044_A16ProductName[0];
            A15ProductId = P00044_A15ProductId[0];
            A85ProductCostPrice = P00044_A85ProductCostPrice[0];
            n85ProductCostPrice = P00044_n85ProductCostPrice[0];
            A17ProductStock = P00044_A17ProductStock[0];
            n17ProductStock = P00044_n17ProductStock[0];
            A40000GXC1 = P00044_A40000GXC1[0];
            n40000GXC1 = P00044_n40000GXC1[0];
            A40001GXC2 = P00044_A40001GXC2[0];
            n40001GXC2 = P00044_n40001GXC2[0];
            A40002GXC3 = P00044_A40002GXC3[0];
            n40002GXC3 = P00044_n40002GXC3[0];
            A40000GXC1 = P00044_A40000GXC1[0];
            n40000GXC1 = P00044_n40000GXC1[0];
            A40001GXC2 = P00044_A40001GXC2[0];
            n40001GXC2 = P00044_n40001GXC2[0];
            A40002GXC3 = P00044_A40002GXC3[0];
            n40002GXC3 = P00044_n40002GXC3[0];
            Gxm1sdtproductsrankingpurchases = new SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem(context);
            Gxm2rootcol.Add(Gxm1sdtproductsrankingpurchases, 0);
            Gxm1sdtproductsrankingpurchases.gxTpr_Id = A15ProductId;
            Gxm1sdtproductsrankingpurchases.gxTpr_Name = A16ProductName;
            Gxm1sdtproductsrankingpurchases.gxTpr_Price = A85ProductCostPrice;
            Gxm1sdtproductsrankingpurchases.gxTpr_Stock = A17ProductStock;
            Gxm1sdtproductsrankingpurchases.gxTpr_Quantitypurchases = (short)(A40000GXC1);
            Gxm1sdtproductsrankingpurchases.gxTpr_Quantityunitspurchases = (short)(A40001GXC2);
            Gxm1sdtproductsrankingpurchases.gxTpr_Total = A40002GXC3;
            Gxm1sdtproductsrankingpurchases.gxTpr_Sector = A9SectorId;
            Gxm1sdtproductsrankingpurchases.gxTpr_Supplier = A4SupplierId;
            Gxm1sdtproductsrankingpurchases.gxTpr_Brand = A1BrandId;
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
         lV8Name = "";
         A16ProductName = "";
         P00044_A4SupplierId = new int[1] ;
         P00044_A9SectorId = new int[1] ;
         P00044_n9SectorId = new bool[] {false} ;
         P00044_A1BrandId = new int[1] ;
         P00044_n1BrandId = new bool[] {false} ;
         P00044_A16ProductName = new string[] {""} ;
         P00044_A15ProductId = new int[1] ;
         P00044_A85ProductCostPrice = new decimal[1] ;
         P00044_n85ProductCostPrice = new bool[] {false} ;
         P00044_A17ProductStock = new int[1] ;
         P00044_n17ProductStock = new bool[] {false} ;
         P00044_A40000GXC1 = new int[1] ;
         P00044_n40000GXC1 = new bool[] {false} ;
         P00044_A40001GXC2 = new int[1] ;
         P00044_n40001GXC2 = new bool[] {false} ;
         P00044_A40002GXC3 = new decimal[1] ;
         P00044_n40002GXC3 = new bool[] {false} ;
         Gxm1sdtproductsrankingpurchases = new SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpproductsrankingpurchases__default(),
            new Object[][] {
                new Object[] {
               P00044_A4SupplierId, P00044_A9SectorId, P00044_n9SectorId, P00044_A1BrandId, P00044_n1BrandId, P00044_A16ProductName, P00044_A15ProductId, P00044_A85ProductCostPrice, P00044_n85ProductCostPrice, P00044_A17ProductStock,
               P00044_n17ProductStock, P00044_A40000GXC1, P00044_n40000GXC1, P00044_A40001GXC2, P00044_n40001GXC2, P00044_A40002GXC3, P00044_n40002GXC3
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV5SupplierId ;
      private int AV6SectorId ;
      private int AV7BrandId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private decimal A85ProductCostPrice ;
      private decimal A40002GXC3 ;
      private string scmdbuf ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool n85ProductCostPrice ;
      private bool n17ProductStock ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private string AV8Name ;
      private string lV8Name ;
      private string A16ProductName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00044_A4SupplierId ;
      private int[] P00044_A9SectorId ;
      private bool[] P00044_n9SectorId ;
      private int[] P00044_A1BrandId ;
      private bool[] P00044_n1BrandId ;
      private string[] P00044_A16ProductName ;
      private int[] P00044_A15ProductId ;
      private decimal[] P00044_A85ProductCostPrice ;
      private bool[] P00044_n85ProductCostPrice ;
      private int[] P00044_A17ProductStock ;
      private bool[] P00044_n17ProductStock ;
      private int[] P00044_A40000GXC1 ;
      private bool[] P00044_n40000GXC1 ;
      private int[] P00044_A40001GXC2 ;
      private bool[] P00044_n40001GXC2 ;
      private decimal[] P00044_A40002GXC3 ;
      private bool[] P00044_n40002GXC3 ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> aP4_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> Gxm2rootcol ;
      private SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem Gxm1sdtproductsrankingpurchases ;
   }

   public class dpproductsrankingpurchases__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00044( IGxContext context ,
                                             string AV8Name ,
                                             int AV7BrandId ,
                                             int AV6SectorId ,
                                             int AV5SupplierId ,
                                             string A16ProductName ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SupplierId], T1.[SectorId], T1.[BrandId], T1.[ProductName], T1.[ProductId], T1.[ProductCostPrice], T1.[ProductStock], COALESCE( T2.[GXC1], 0) AS GXC1, COALESCE( T2.[GXC2], 0) AS GXC2, COALESCE( T3.[GXC3], 0) AS GXC3 FROM (([Product] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [ProductId], SUM([PurchaseOrderDetailQuantityOrd]) AS GXC2 FROM [PurchaseOrderDetail] GROUP BY [ProductId] ) T2 ON T2.[ProductId] = T1.[ProductId]) LEFT JOIN (SELECT SUM(T5.[PurchaseOrderTotalPaid]) AS GXC3, T4.[ProductId] FROM ([PurchaseOrderDetail] T4 INNER JOIN [PurchaseOrder] T5 ON T5.[PurchaseOrderId] = T4.[PurchaseOrderId]) GROUP BY T4.[ProductId] ) T3 ON T3.[ProductId] = T1.[ProductId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV8Name)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV7BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV7BrandId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV6SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV6SectorId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV5SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV5SupplierId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProductId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00044(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00044;
          prmP00044 = new Object[] {
          new ParDef("@lV8Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV7BrandId",GXType.Int32,6,0) ,
          new ParDef("@AV6SectorId",GXType.Int32,6,0) ,
          new ParDef("@AV5SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00044", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00044,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((int[]) buf[11])[0] = rslt.getInt(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((int[]) buf[13])[0] = rslt.getInt(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
