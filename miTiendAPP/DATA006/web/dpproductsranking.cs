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
   public class dpproductsranking : GXProcedure
   {
      public dpproductsranking( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpproductsranking( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           int aP1_SupplierId ,
                           int aP2_SectorId ,
                           int aP3_BrandId ,
                           out GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem> aP4_Gxm2rootcol )
      {
         this.AV10Name = aP0_Name;
         this.AV8SupplierId = aP1_SupplierId;
         this.AV5SectorId = aP2_SectorId;
         this.AV6BrandId = aP3_BrandId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem>( context, "SDTRankingProductsItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem> executeUdp( string aP0_Name ,
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
                                 out GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem> aP4_Gxm2rootcol )
      {
         dpproductsranking objdpproductsranking;
         objdpproductsranking = new dpproductsranking();
         objdpproductsranking.AV10Name = aP0_Name;
         objdpproductsranking.AV8SupplierId = aP1_SupplierId;
         objdpproductsranking.AV5SectorId = aP2_SectorId;
         objdpproductsranking.AV6BrandId = aP3_BrandId;
         objdpproductsranking.Gxm2rootcol = new GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem>( context, "SDTRankingProductsItem", "mtaKB") ;
         objdpproductsranking.context.SetSubmitInitialConfig(context);
         objdpproductsranking.initialize();
         Submit( executePrivateCatch,objdpproductsranking);
         aP4_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpproductsranking)stateInfo).executePrivate();
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
                                              AV10Name ,
                                              AV6BrandId ,
                                              AV5SectorId ,
                                              AV8SupplierId ,
                                              A16ProductName ,
                                              A1BrandId ,
                                              A9SectorId ,
                                              A4SupplierId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV10Name = StringUtil.Concat( StringUtil.RTrim( AV10Name), "%", "");
         /* Using cursor P00053 */
         pr_default.execute(0, new Object[] {lV10Name, AV6BrandId, AV5SectorId, AV8SupplierId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P00053_A4SupplierId[0];
            A9SectorId = P00053_A9SectorId[0];
            A1BrandId = P00053_A1BrandId[0];
            A16ProductName = P00053_A16ProductName[0];
            A15ProductId = P00053_A15ProductId[0];
            A18ProductPrice = P00053_A18ProductPrice[0];
            A17ProductStock = P00053_A17ProductStock[0];
            A5SupplierName = P00053_A5SupplierName[0];
            A10SectorName = P00053_A10SectorName[0];
            A2BrandName = P00053_A2BrandName[0];
            A40000GXC1 = P00053_A40000GXC1[0];
            n40000GXC1 = P00053_n40000GXC1[0];
            A40001GXC2 = P00053_A40001GXC2[0];
            n40001GXC2 = P00053_n40001GXC2[0];
            A40002GXC3 = P00053_A40002GXC3[0];
            n40002GXC3 = P00053_n40002GXC3[0];
            A5SupplierName = P00053_A5SupplierName[0];
            A10SectorName = P00053_A10SectorName[0];
            A2BrandName = P00053_A2BrandName[0];
            A40000GXC1 = P00053_A40000GXC1[0];
            n40000GXC1 = P00053_n40000GXC1[0];
            A40001GXC2 = P00053_A40001GXC2[0];
            n40001GXC2 = P00053_n40001GXC2[0];
            A40002GXC3 = P00053_A40002GXC3[0];
            n40002GXC3 = P00053_n40002GXC3[0];
            Gxm1sdtrankingproducts = new SdtSDTRankingProducts_SDTRankingProductsItem(context);
            Gxm2rootcol.Add(Gxm1sdtrankingproducts, 0);
            Gxm1sdtrankingproducts.gxTpr_Id = A15ProductId;
            Gxm1sdtrankingproducts.gxTpr_Name = A16ProductName;
            Gxm1sdtrankingproducts.gxTpr_Price = A18ProductPrice;
            Gxm1sdtrankingproducts.gxTpr_Stock = A17ProductStock;
            Gxm1sdtrankingproducts.gxTpr_Supplier = A5SupplierName;
            Gxm1sdtrankingproducts.gxTpr_Sector = A10SectorName;
            Gxm1sdtrankingproducts.gxTpr_Brand = A2BrandName;
            Gxm1sdtrankingproducts.gxTpr_Quantitysales = A40000GXC1;
            Gxm1sdtrankingproducts.gxTpr_Quantityunitssale = A40001GXC2;
            Gxm1sdtrankingproducts.gxTpr_Subtotal = (decimal)(A40002GXC3);
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
         lV10Name = "";
         A16ProductName = "";
         P00053_A4SupplierId = new int[1] ;
         P00053_A9SectorId = new int[1] ;
         P00053_A1BrandId = new int[1] ;
         P00053_A16ProductName = new string[] {""} ;
         P00053_A15ProductId = new int[1] ;
         P00053_A18ProductPrice = new decimal[1] ;
         P00053_A17ProductStock = new int[1] ;
         P00053_A5SupplierName = new string[] {""} ;
         P00053_A10SectorName = new string[] {""} ;
         P00053_A2BrandName = new string[] {""} ;
         P00053_A40000GXC1 = new int[1] ;
         P00053_n40000GXC1 = new bool[] {false} ;
         P00053_A40001GXC2 = new int[1] ;
         P00053_n40001GXC2 = new bool[] {false} ;
         P00053_A40002GXC3 = new long[1] ;
         P00053_n40002GXC3 = new bool[] {false} ;
         A5SupplierName = "";
         A10SectorName = "";
         A2BrandName = "";
         Gxm1sdtrankingproducts = new SdtSDTRankingProducts_SDTRankingProductsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpproductsranking__default(),
            new Object[][] {
                new Object[] {
               P00053_A4SupplierId, P00053_A9SectorId, P00053_A1BrandId, P00053_A16ProductName, P00053_A15ProductId, P00053_A18ProductPrice, P00053_A17ProductStock, P00053_A5SupplierName, P00053_A10SectorName, P00053_A2BrandName,
               P00053_A40000GXC1, P00053_n40000GXC1, P00053_A40001GXC2, P00053_n40001GXC2, P00053_A40002GXC3, P00053_n40002GXC3
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8SupplierId ;
      private int AV5SectorId ;
      private int AV6BrandId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private long A40002GXC3 ;
      private decimal A18ProductPrice ;
      private string scmdbuf ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private string AV10Name ;
      private string lV10Name ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A10SectorName ;
      private string A2BrandName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00053_A4SupplierId ;
      private int[] P00053_A9SectorId ;
      private int[] P00053_A1BrandId ;
      private string[] P00053_A16ProductName ;
      private int[] P00053_A15ProductId ;
      private decimal[] P00053_A18ProductPrice ;
      private int[] P00053_A17ProductStock ;
      private string[] P00053_A5SupplierName ;
      private string[] P00053_A10SectorName ;
      private string[] P00053_A2BrandName ;
      private int[] P00053_A40000GXC1 ;
      private bool[] P00053_n40000GXC1 ;
      private int[] P00053_A40001GXC2 ;
      private bool[] P00053_n40001GXC2 ;
      private long[] P00053_A40002GXC3 ;
      private bool[] P00053_n40002GXC3 ;
      private GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem> aP4_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem> Gxm2rootcol ;
      private SdtSDTRankingProducts_SDTRankingProductsItem Gxm1sdtrankingproducts ;
   }

   public class dpproductsranking__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00053( IGxContext context ,
                                             string AV10Name ,
                                             int AV6BrandId ,
                                             int AV5SectorId ,
                                             int AV8SupplierId ,
                                             string A16ProductName ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SupplierId], T1.[SectorId], T1.[BrandId], T1.[ProductName], T1.[ProductId], T1.[ProductPrice], T1.[ProductStock], T2.[SupplierName], T3.[SectorName], T4.[BrandName], COALESCE( T5.[GXC1], 0) AS GXC1, COALESCE( T5.[GXC2], 0) AS GXC2, COALESCE( T5.[GXC3], 0) AS GXC3 FROM (((([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T4 ON T4.[BrandId] = T1.[BrandId]) LEFT JOIN (SELECT COUNT(*) AS GXC1, [ProductId], SUM([InvoiceDetailQuantity]) AS GXC2, SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 20, 10))) AS GXC3 FROM [InvoiceDetail] GROUP BY [ProductId] ) T5 ON T5.[ProductId] = T1.[ProductId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV10Name)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV6BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV6BrandId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV5SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV5SectorId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV8SupplierId)");
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
                     return conditional_P00053(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
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
          Object[] prmP00053;
          prmP00053 = new Object[] {
          new ParDef("@lV10Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV6BrandId",GXType.Int32,6,0) ,
          new ParDef("@AV5SectorId",GXType.Int32,6,0) ,
          new ParDef("@AV8SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00053", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00053,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((long[]) buf[14])[0] = rslt.getLong(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
