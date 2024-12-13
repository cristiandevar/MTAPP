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
   public class dpallproductswhere : GXProcedure
   {
      public dpallproductswhere( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpallproductswhere( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           string aP1_Code ,
                           int aP2_SupplierId ,
                           int aP3_SectorId ,
                           int aP4_BrandId ,
                           int aP5_StockFrom ,
                           int aP6_StockTo ,
                           decimal aP7_PriceFrom ,
                           decimal aP8_PriceTo ,
                           out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP9_Gxm2rootcol )
      {
         this.AV7Name = aP0_Name;
         this.AV6Code = aP1_Code;
         this.AV5SupplierId = aP2_SupplierId;
         this.AV8SectorId = aP3_SectorId;
         this.AV9BrandId = aP4_BrandId;
         this.AV10StockFrom = aP5_StockFrom;
         this.AV11StockTo = aP6_StockTo;
         this.AV12PriceFrom = aP7_PriceFrom;
         this.AV13PriceTo = aP8_PriceTo;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP9_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> executeUdp( string aP0_Name ,
                                                                                          string aP1_Code ,
                                                                                          int aP2_SupplierId ,
                                                                                          int aP3_SectorId ,
                                                                                          int aP4_BrandId ,
                                                                                          int aP5_StockFrom ,
                                                                                          int aP6_StockTo ,
                                                                                          decimal aP7_PriceFrom ,
                                                                                          decimal aP8_PriceTo )
      {
         execute(aP0_Name, aP1_Code, aP2_SupplierId, aP3_SectorId, aP4_BrandId, aP5_StockFrom, aP6_StockTo, aP7_PriceFrom, aP8_PriceTo, out aP9_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_Name ,
                                 string aP1_Code ,
                                 int aP2_SupplierId ,
                                 int aP3_SectorId ,
                                 int aP4_BrandId ,
                                 int aP5_StockFrom ,
                                 int aP6_StockTo ,
                                 decimal aP7_PriceFrom ,
                                 decimal aP8_PriceTo ,
                                 out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP9_Gxm2rootcol )
      {
         dpallproductswhere objdpallproductswhere;
         objdpallproductswhere = new dpallproductswhere();
         objdpallproductswhere.AV7Name = aP0_Name;
         objdpallproductswhere.AV6Code = aP1_Code;
         objdpallproductswhere.AV5SupplierId = aP2_SupplierId;
         objdpallproductswhere.AV8SectorId = aP3_SectorId;
         objdpallproductswhere.AV9BrandId = aP4_BrandId;
         objdpallproductswhere.AV10StockFrom = aP5_StockFrom;
         objdpallproductswhere.AV11StockTo = aP6_StockTo;
         objdpallproductswhere.AV12PriceFrom = aP7_PriceFrom;
         objdpallproductswhere.AV13PriceTo = aP8_PriceTo;
         objdpallproductswhere.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         objdpallproductswhere.context.SetSubmitInitialConfig(context);
         objdpallproductswhere.initialize();
         Submit( executePrivateCatch,objdpallproductswhere);
         aP9_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpallproductswhere)stateInfo).executePrivate();
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
                                              AV13PriceTo ,
                                              AV12PriceFrom ,
                                              AV11StockTo ,
                                              AV10StockFrom ,
                                              AV6Code ,
                                              AV7Name ,
                                              AV9BrandId ,
                                              AV8SectorId ,
                                              AV5SupplierId ,
                                              A18ProductPrice ,
                                              A17ProductStock ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A1BrandId ,
                                              A9SectorId ,
                                              A4SupplierId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV6Code = StringUtil.Concat( StringUtil.RTrim( AV6Code), "%", "");
         lV7Name = StringUtil.Concat( StringUtil.RTrim( AV7Name), "%", "");
         /* Using cursor P00062 */
         pr_default.execute(0, new Object[] {AV13PriceTo, AV12PriceFrom, AV11StockTo, AV10StockFrom, lV6Code, lV7Name, AV9BrandId, AV8SectorId, AV5SupplierId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P00062_A4SupplierId[0];
            A9SectorId = P00062_A9SectorId[0];
            A1BrandId = P00062_A1BrandId[0];
            A16ProductName = P00062_A16ProductName[0];
            A55ProductCode = P00062_A55ProductCode[0];
            n55ProductCode = P00062_n55ProductCode[0];
            A17ProductStock = P00062_A17ProductStock[0];
            A18ProductPrice = P00062_A18ProductPrice[0];
            A15ProductId = P00062_A15ProductId[0];
            A10SectorName = P00062_A10SectorName[0];
            A5SupplierName = P00062_A5SupplierName[0];
            A2BrandName = P00062_A2BrandName[0];
            A5SupplierName = P00062_A5SupplierName[0];
            A10SectorName = P00062_A10SectorName[0];
            A2BrandName = P00062_A2BrandName[0];
            Gxm1sdtproductsselected = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            Gxm2rootcol.Add(Gxm1sdtproductsselected, 0);
            Gxm1sdtproductsselected.gxTpr_Id = A15ProductId;
            Gxm1sdtproductsselected.gxTpr_Code = A55ProductCode;
            Gxm1sdtproductsselected.gxTpr_Name = A16ProductName;
            Gxm1sdtproductsselected.gxTpr_Unitprice = A18ProductPrice;
            Gxm1sdtproductsselected.gxTpr_Newunitprice = A18ProductPrice;
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
         lV6Code = "";
         lV7Name = "";
         A55ProductCode = "";
         A16ProductName = "";
         P00062_A4SupplierId = new int[1] ;
         P00062_A9SectorId = new int[1] ;
         P00062_A1BrandId = new int[1] ;
         P00062_A16ProductName = new string[] {""} ;
         P00062_A55ProductCode = new string[] {""} ;
         P00062_n55ProductCode = new bool[] {false} ;
         P00062_A17ProductStock = new int[1] ;
         P00062_A18ProductPrice = new decimal[1] ;
         P00062_A15ProductId = new int[1] ;
         P00062_A10SectorName = new string[] {""} ;
         P00062_A5SupplierName = new string[] {""} ;
         P00062_A2BrandName = new string[] {""} ;
         A10SectorName = "";
         A5SupplierName = "";
         A2BrandName = "";
         Gxm1sdtproductsselected = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpallproductswhere__default(),
            new Object[][] {
                new Object[] {
               P00062_A4SupplierId, P00062_A9SectorId, P00062_A1BrandId, P00062_A16ProductName, P00062_A55ProductCode, P00062_n55ProductCode, P00062_A17ProductStock, P00062_A18ProductPrice, P00062_A15ProductId, P00062_A10SectorName,
               P00062_A5SupplierName, P00062_A2BrandName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV5SupplierId ;
      private int AV8SectorId ;
      private int AV9BrandId ;
      private int AV10StockFrom ;
      private int AV11StockTo ;
      private int A17ProductStock ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private decimal AV12PriceFrom ;
      private decimal AV13PriceTo ;
      private decimal A18ProductPrice ;
      private string scmdbuf ;
      private bool n55ProductCode ;
      private string AV7Name ;
      private string AV6Code ;
      private string lV6Code ;
      private string lV7Name ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A10SectorName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00062_A4SupplierId ;
      private int[] P00062_A9SectorId ;
      private int[] P00062_A1BrandId ;
      private string[] P00062_A16ProductName ;
      private string[] P00062_A55ProductCode ;
      private bool[] P00062_n55ProductCode ;
      private int[] P00062_A17ProductStock ;
      private decimal[] P00062_A18ProductPrice ;
      private int[] P00062_A15ProductId ;
      private string[] P00062_A10SectorName ;
      private string[] P00062_A5SupplierName ;
      private string[] P00062_A2BrandName ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP9_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> Gxm2rootcol ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem Gxm1sdtproductsselected ;
   }

   public class dpallproductswhere__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00062( IGxContext context ,
                                             decimal AV13PriceTo ,
                                             decimal AV12PriceFrom ,
                                             int AV11StockTo ,
                                             int AV10StockFrom ,
                                             string AV6Code ,
                                             string AV7Name ,
                                             int AV9BrandId ,
                                             int AV8SectorId ,
                                             int AV5SupplierId ,
                                             decimal A18ProductPrice ,
                                             int A17ProductStock ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SupplierId], T1.[SectorId], T1.[BrandId], T1.[ProductName], T1.[ProductCode], T1.[ProductStock], T1.[ProductPrice], T1.[ProductId], T3.[SectorName], T2.[SupplierName], T4.[BrandName] FROM ((([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T4 ON T4.[BrandId] = T1.[BrandId])";
         if ( ! (Convert.ToDecimal(0)==AV13PriceTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductPrice] <= @AV13PriceTo)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV12PriceFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductPrice] >= @AV12PriceFrom)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV11StockTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] <= @AV11StockTo)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV10StockFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] >= @AV10StockFrom)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV6Code)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV7Name)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV9BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV9BrandId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV8SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV8SectorId)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV5SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV5SupplierId)");
         }
         else
         {
            GXv_int1[8] = 1;
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
                     return conditional_P00062(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] );
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
          Object[] prmP00062;
          prmP00062 = new Object[] {
          new ParDef("@AV13PriceTo",GXType.Decimal,10,2) ,
          new ParDef("@AV12PriceFrom",GXType.Decimal,10,2) ,
          new ParDef("@AV11StockTo",GXType.Int32,6,0) ,
          new ParDef("@AV10StockFrom",GXType.Int32,6,0) ,
          new ParDef("@lV6Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV7Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV9BrandId",GXType.Int32,6,0) ,
          new ParDef("@AV8SectorId",GXType.Int32,6,0) ,
          new ParDef("@AV5SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00062", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00062,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                return;
       }
    }

 }

}
