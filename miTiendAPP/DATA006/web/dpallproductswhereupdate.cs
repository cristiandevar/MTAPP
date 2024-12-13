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
   public class dpallproductswhereupdate : GXProcedure
   {
      public dpallproductswhereupdate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public dpallproductswhereupdate( IGxContext context )
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
                           out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP5_Gxm2rootcol )
      {
         this.AV7Name = aP0_Name;
         this.AV6Code = aP1_Code;
         this.AV5SupplierId = aP2_SupplierId;
         this.AV8SectorId = aP3_SectorId;
         this.AV9BrandId = aP4_BrandId;
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP5_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> executeUdp( string aP0_Name ,
                                                                                          string aP1_Code ,
                                                                                          int aP2_SupplierId ,
                                                                                          int aP3_SectorId ,
                                                                                          int aP4_BrandId )
      {
         execute(aP0_Name, aP1_Code, aP2_SupplierId, aP3_SectorId, aP4_BrandId, out aP5_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( string aP0_Name ,
                                 string aP1_Code ,
                                 int aP2_SupplierId ,
                                 int aP3_SectorId ,
                                 int aP4_BrandId ,
                                 out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP5_Gxm2rootcol )
      {
         dpallproductswhereupdate objdpallproductswhereupdate;
         objdpallproductswhereupdate = new dpallproductswhereupdate();
         objdpallproductswhereupdate.AV7Name = aP0_Name;
         objdpallproductswhereupdate.AV6Code = aP1_Code;
         objdpallproductswhereupdate.AV5SupplierId = aP2_SupplierId;
         objdpallproductswhereupdate.AV8SectorId = aP3_SectorId;
         objdpallproductswhereupdate.AV9BrandId = aP4_BrandId;
         objdpallproductswhereupdate.Gxm2rootcol = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         objdpallproductswhereupdate.context.SetSubmitInitialConfig(context);
         objdpallproductswhereupdate.initialize();
         Submit( executePrivateCatch,objdpallproductswhereupdate);
         aP5_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpallproductswhereupdate)stateInfo).executePrivate();
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
                                              AV6Code ,
                                              AV7Name ,
                                              AV9BrandId ,
                                              AV8SectorId ,
                                              AV5SupplierId ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A1BrandId ,
                                              A9SectorId ,
                                              A4SupplierId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV6Code = StringUtil.Concat( StringUtil.RTrim( AV6Code), "%", "");
         lV7Name = StringUtil.Concat( StringUtil.RTrim( AV7Name), "%", "");
         /* Using cursor P00082 */
         pr_default.execute(0, new Object[] {lV6Code, lV7Name, AV9BrandId, AV8SectorId, AV5SupplierId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P00082_A4SupplierId[0];
            A9SectorId = P00082_A9SectorId[0];
            A1BrandId = P00082_A1BrandId[0];
            A16ProductName = P00082_A16ProductName[0];
            A55ProductCode = P00082_A55ProductCode[0];
            n55ProductCode = P00082_n55ProductCode[0];
            A15ProductId = P00082_A15ProductId[0];
            A10SectorName = P00082_A10SectorName[0];
            A5SupplierName = P00082_A5SupplierName[0];
            A2BrandName = P00082_A2BrandName[0];
            A18ProductPrice = P00082_A18ProductPrice[0];
            A85ProductCostPrice = P00082_A85ProductCostPrice[0];
            A89ProductRetailProfit = P00082_A89ProductRetailProfit[0];
            n89ProductRetailProfit = P00082_n89ProductRetailProfit[0];
            A87ProductWholesaleProfit = P00082_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = P00082_n87ProductWholesaleProfit[0];
            A5SupplierName = P00082_A5SupplierName[0];
            A10SectorName = P00082_A10SectorName[0];
            A2BrandName = P00082_A2BrandName[0];
            Gxm1sdtproductsselected = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            Gxm2rootcol.Add(Gxm1sdtproductsselected, 0);
            Gxm1sdtproductsselected.gxTpr_Id = A15ProductId;
            Gxm1sdtproductsselected.gxTpr_Code = A55ProductCode;
            Gxm1sdtproductsselected.gxTpr_Name = A16ProductName;
            Gxm1sdtproductsselected.gxTpr_Sector = A10SectorName;
            Gxm1sdtproductsselected.gxTpr_Supplier = A5SupplierName;
            Gxm1sdtproductsselected.gxTpr_Brand = A2BrandName;
            Gxm1sdtproductsselected.gxTpr_Unitprice = A18ProductPrice;
            Gxm1sdtproductsselected.gxTpr_Newunitprice = A18ProductPrice;
            Gxm1sdtproductsselected.gxTpr_Costprice = A85ProductCostPrice;
            Gxm1sdtproductsselected.gxTpr_Retailprofit = A89ProductRetailProfit;
            Gxm1sdtproductsselected.gxTpr_Wholesaleprofit = A87ProductWholesaleProfit;
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
         P00082_A4SupplierId = new int[1] ;
         P00082_A9SectorId = new int[1] ;
         P00082_A1BrandId = new int[1] ;
         P00082_A16ProductName = new string[] {""} ;
         P00082_A55ProductCode = new string[] {""} ;
         P00082_n55ProductCode = new bool[] {false} ;
         P00082_A15ProductId = new int[1] ;
         P00082_A10SectorName = new string[] {""} ;
         P00082_A5SupplierName = new string[] {""} ;
         P00082_A2BrandName = new string[] {""} ;
         P00082_A18ProductPrice = new decimal[1] ;
         P00082_A85ProductCostPrice = new decimal[1] ;
         P00082_A89ProductRetailProfit = new decimal[1] ;
         P00082_n89ProductRetailProfit = new bool[] {false} ;
         P00082_A87ProductWholesaleProfit = new decimal[1] ;
         P00082_n87ProductWholesaleProfit = new bool[] {false} ;
         A10SectorName = "";
         A5SupplierName = "";
         A2BrandName = "";
         Gxm1sdtproductsselected = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpallproductswhereupdate__default(),
            new Object[][] {
                new Object[] {
               P00082_A4SupplierId, P00082_A9SectorId, P00082_A1BrandId, P00082_A16ProductName, P00082_A55ProductCode, P00082_n55ProductCode, P00082_A15ProductId, P00082_A10SectorName, P00082_A5SupplierName, P00082_A2BrandName,
               P00082_A18ProductPrice, P00082_A85ProductCostPrice, P00082_A89ProductRetailProfit, P00082_n89ProductRetailProfit, P00082_A87ProductWholesaleProfit, P00082_n87ProductWholesaleProfit
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV5SupplierId ;
      private int AV8SectorId ;
      private int AV9BrandId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private decimal A18ProductPrice ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private string scmdbuf ;
      private bool n55ProductCode ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
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
      private int[] P00082_A4SupplierId ;
      private int[] P00082_A9SectorId ;
      private int[] P00082_A1BrandId ;
      private string[] P00082_A16ProductName ;
      private string[] P00082_A55ProductCode ;
      private bool[] P00082_n55ProductCode ;
      private int[] P00082_A15ProductId ;
      private string[] P00082_A10SectorName ;
      private string[] P00082_A5SupplierName ;
      private string[] P00082_A2BrandName ;
      private decimal[] P00082_A18ProductPrice ;
      private decimal[] P00082_A85ProductCostPrice ;
      private decimal[] P00082_A89ProductRetailProfit ;
      private bool[] P00082_n89ProductRetailProfit ;
      private decimal[] P00082_A87ProductWholesaleProfit ;
      private bool[] P00082_n87ProductWholesaleProfit ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP5_Gxm2rootcol ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> Gxm2rootcol ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem Gxm1sdtproductsselected ;
   }

   public class dpallproductswhereupdate__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00082( IGxContext context ,
                                             string AV6Code ,
                                             string AV7Name ,
                                             int AV9BrandId ,
                                             int AV8SectorId ,
                                             int AV5SupplierId ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SupplierId], T1.[SectorId], T1.[BrandId], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T3.[SectorName], T2.[SupplierName], T4.[BrandName], T1.[ProductPrice], T1.[ProductCostPrice], T1.[ProductRetailProfit], T1.[ProductWholesaleProfit] FROM ((([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T4 ON T4.[BrandId] = T1.[BrandId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV6Code)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV7Name)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV9BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV9BrandId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV8SectorId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV5SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV5SupplierId)");
         }
         else
         {
            GXv_int1[4] = 1;
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
                     return conditional_P00082(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
          Object[] prmP00082;
          prmP00082 = new Object[] {
          new ParDef("@lV6Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV7Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV9BrandId",GXType.Int32,6,0) ,
          new ParDef("@AV8SectorId",GXType.Int32,6,0) ,
          new ParDef("@AV5SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00082", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00082,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
