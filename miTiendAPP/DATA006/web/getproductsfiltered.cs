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
   public class getproductsfiltered : GXProcedure
   {
      public getproductsfiltered( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public getproductsfiltered( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Code ,
                           ref string aP1_Name ,
                           ref int aP2_SupplierId ,
                           ref int aP3_SectorId ,
                           ref int aP4_BrandId ,
                           ref bool aP5_Ordered ,
                           ref bool aP6_Necesary ,
                           out GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> aP7_SDTProductsFiltered )
      {
         this.AV10Code = aP0_Code;
         this.AV13Name = aP1_Name;
         this.AV22SupplierId = aP2_SupplierId;
         this.AV18SectorId = aP3_SectorId;
         this.AV8BrandId = aP4_BrandId;
         this.AV32Ordered = aP5_Ordered;
         this.AV31Necesary = aP6_Necesary;
         this.AV30SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP1_Name=this.AV13Name;
         aP2_SupplierId=this.AV22SupplierId;
         aP3_SectorId=this.AV18SectorId;
         aP4_BrandId=this.AV8BrandId;
         aP5_Ordered=this.AV32Ordered;
         aP6_Necesary=this.AV31Necesary;
         aP7_SDTProductsFiltered=this.AV30SDTProductsFiltered;
      }

      public GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> executeUdp( string aP0_Code ,
                                                                                          ref string aP1_Name ,
                                                                                          ref int aP2_SupplierId ,
                                                                                          ref int aP3_SectorId ,
                                                                                          ref int aP4_BrandId ,
                                                                                          ref bool aP5_Ordered ,
                                                                                          ref bool aP6_Necesary )
      {
         execute(aP0_Code, ref aP1_Name, ref aP2_SupplierId, ref aP3_SectorId, ref aP4_BrandId, ref aP5_Ordered, ref aP6_Necesary, out aP7_SDTProductsFiltered);
         return AV30SDTProductsFiltered ;
      }

      public void executeSubmit( string aP0_Code ,
                                 ref string aP1_Name ,
                                 ref int aP2_SupplierId ,
                                 ref int aP3_SectorId ,
                                 ref int aP4_BrandId ,
                                 ref bool aP5_Ordered ,
                                 ref bool aP6_Necesary ,
                                 out GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> aP7_SDTProductsFiltered )
      {
         getproductsfiltered objgetproductsfiltered;
         objgetproductsfiltered = new getproductsfiltered();
         objgetproductsfiltered.AV10Code = aP0_Code;
         objgetproductsfiltered.AV13Name = aP1_Name;
         objgetproductsfiltered.AV22SupplierId = aP2_SupplierId;
         objgetproductsfiltered.AV18SectorId = aP3_SectorId;
         objgetproductsfiltered.AV8BrandId = aP4_BrandId;
         objgetproductsfiltered.AV32Ordered = aP5_Ordered;
         objgetproductsfiltered.AV31Necesary = aP6_Necesary;
         objgetproductsfiltered.AV30SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB") ;
         objgetproductsfiltered.context.SetSubmitInitialConfig(context);
         objgetproductsfiltered.initialize();
         Submit( executePrivateCatch,objgetproductsfiltered);
         aP1_Name=this.AV13Name;
         aP2_SupplierId=this.AV22SupplierId;
         aP3_SectorId=this.AV18SectorId;
         aP4_BrandId=this.AV8BrandId;
         aP5_Ordered=this.AV32Ordered;
         aP6_Necesary=this.AV31Necesary;
         aP7_SDTProductsFiltered=this.AV30SDTProductsFiltered;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getproductsfiltered)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV37Context, ref  AV35AllOk) ;
         if ( ! AV35AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         if ( AV32Ordered )
         {
            GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1 = AV28SDTProductsSelected;
            new dpallproductswhereordered(context ).execute( out  GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1) ;
            AV28SDTProductsSelected = GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1;
         }
         AV30SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10Code ,
                                              AV13Name ,
                                              AV22SupplierId ,
                                              AV8BrandId ,
                                              AV18SectorId ,
                                              AV31Necesary ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A4SupplierId ,
                                              A1BrandId ,
                                              A9SectorId ,
                                              A17ProductStock ,
                                              A69ProductMiniumStock ,
                                              A110ProductActive ,
                                              A112SupplierActive } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV10Code = StringUtil.Concat( StringUtil.RTrim( AV10Code), "%", "");
         lV13Name = StringUtil.Concat( StringUtil.RTrim( AV13Name), "%", "");
         /* Using cursor P00182 */
         pr_default.execute(0, new Object[] {lV10Code, lV13Name, AV22SupplierId, AV8BrandId, AV18SectorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112SupplierActive = P00182_A112SupplierActive[0];
            A110ProductActive = P00182_A110ProductActive[0];
            n110ProductActive = P00182_n110ProductActive[0];
            A69ProductMiniumStock = P00182_A69ProductMiniumStock[0];
            n69ProductMiniumStock = P00182_n69ProductMiniumStock[0];
            A17ProductStock = P00182_A17ProductStock[0];
            n17ProductStock = P00182_n17ProductStock[0];
            A9SectorId = P00182_A9SectorId[0];
            n9SectorId = P00182_n9SectorId[0];
            A1BrandId = P00182_A1BrandId[0];
            n1BrandId = P00182_n1BrandId[0];
            A4SupplierId = P00182_A4SupplierId[0];
            A16ProductName = P00182_A16ProductName[0];
            A55ProductCode = P00182_A55ProductCode[0];
            n55ProductCode = P00182_n55ProductCode[0];
            A15ProductId = P00182_A15ProductId[0];
            A2BrandName = P00182_A2BrandName[0];
            A5SupplierName = P00182_A5SupplierName[0];
            A10SectorName = P00182_A10SectorName[0];
            A85ProductCostPrice = P00182_A85ProductCostPrice[0];
            n85ProductCostPrice = P00182_n85ProductCostPrice[0];
            A10SectorName = P00182_A10SectorName[0];
            A2BrandName = P00182_A2BrandName[0];
            A112SupplierActive = P00182_A112SupplierActive[0];
            A5SupplierName = P00182_A5SupplierName[0];
            AV27ProductId = A15ProductId;
            AV35AllOk = true;
            if ( AV32Ordered )
            {
               AV36WasOrdered = false;
               /* Execute user subroutine: 'WASORDERED' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV35AllOk = (bool)(!AV36WasOrdered);
            }
            if ( AV35AllOk )
            {
               AV33SDTProductsFilteredItem = new SdtSDTProductsFiltered_SDTProductsFilteredItem(context);
               AV33SDTProductsFilteredItem.gxTpr_Id = A15ProductId;
               AV33SDTProductsFilteredItem.gxTpr_Name = A16ProductName;
               AV33SDTProductsFilteredItem.gxTpr_Code = A55ProductCode;
               AV33SDTProductsFilteredItem.gxTpr_Brand = A2BrandName;
               AV33SDTProductsFilteredItem.gxTpr_Supplier = A5SupplierName;
               AV33SDTProductsFilteredItem.gxTpr_Sector = A10SectorName;
               AV33SDTProductsFilteredItem.gxTpr_Stock = A17ProductStock;
               AV33SDTProductsFilteredItem.gxTpr_Miniumstock = A69ProductMiniumStock;
               AV33SDTProductsFilteredItem.gxTpr_Costprice = A85ProductCostPrice;
               AV30SDTProductsFiltered.Add(AV33SDTProductsFilteredItem, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'WASORDERED' Routine */
         returnInSub = false;
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV28SDTProductsSelected.Count )
         {
            AV29SDTProductsSelectedItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28SDTProductsSelected.Item(AV46GXV1));
            if ( AV29SDTProductsSelectedItem.gxTpr_Id == AV27ProductId )
            {
               AV36WasOrdered = true;
               if (true) break;
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
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
         AV30SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         AV37Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV28SDTProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1 = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         scmdbuf = "";
         lV10Code = "";
         lV13Name = "";
         A55ProductCode = "";
         A16ProductName = "";
         P00182_A112SupplierActive = new bool[] {false} ;
         P00182_A110ProductActive = new bool[] {false} ;
         P00182_n110ProductActive = new bool[] {false} ;
         P00182_A69ProductMiniumStock = new int[1] ;
         P00182_n69ProductMiniumStock = new bool[] {false} ;
         P00182_A17ProductStock = new int[1] ;
         P00182_n17ProductStock = new bool[] {false} ;
         P00182_A9SectorId = new int[1] ;
         P00182_n9SectorId = new bool[] {false} ;
         P00182_A1BrandId = new int[1] ;
         P00182_n1BrandId = new bool[] {false} ;
         P00182_A4SupplierId = new int[1] ;
         P00182_A16ProductName = new string[] {""} ;
         P00182_A55ProductCode = new string[] {""} ;
         P00182_n55ProductCode = new bool[] {false} ;
         P00182_A15ProductId = new int[1] ;
         P00182_A2BrandName = new string[] {""} ;
         P00182_A5SupplierName = new string[] {""} ;
         P00182_A10SectorName = new string[] {""} ;
         P00182_A85ProductCostPrice = new decimal[1] ;
         P00182_n85ProductCostPrice = new bool[] {false} ;
         A2BrandName = "";
         A5SupplierName = "";
         A10SectorName = "";
         AV33SDTProductsFilteredItem = new SdtSDTProductsFiltered_SDTProductsFilteredItem(context);
         AV29SDTProductsSelectedItem = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.getproductsfiltered__default(),
            new Object[][] {
                new Object[] {
               P00182_A112SupplierActive, P00182_A110ProductActive, P00182_n110ProductActive, P00182_A69ProductMiniumStock, P00182_n69ProductMiniumStock, P00182_A17ProductStock, P00182_n17ProductStock, P00182_A9SectorId, P00182_n9SectorId, P00182_A1BrandId,
               P00182_n1BrandId, P00182_A4SupplierId, P00182_A16ProductName, P00182_A55ProductCode, P00182_n55ProductCode, P00182_A15ProductId, P00182_A2BrandName, P00182_A5SupplierName, P00182_A10SectorName, P00182_A85ProductCostPrice,
               P00182_n85ProductCostPrice
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV22SupplierId ;
      private int AV18SectorId ;
      private int AV8BrandId ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A17ProductStock ;
      private int A69ProductMiniumStock ;
      private int A15ProductId ;
      private int AV27ProductId ;
      private int AV46GXV1 ;
      private decimal A85ProductCostPrice ;
      private string scmdbuf ;
      private bool AV32Ordered ;
      private bool AV31Necesary ;
      private bool AV35AllOk ;
      private bool A110ProductActive ;
      private bool A112SupplierActive ;
      private bool n110ProductActive ;
      private bool n69ProductMiniumStock ;
      private bool n17ProductStock ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool n55ProductCode ;
      private bool n85ProductCostPrice ;
      private bool AV36WasOrdered ;
      private bool returnInSub ;
      private string AV10Code ;
      private string AV13Name ;
      private string lV10Code ;
      private string lV13Name ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A2BrandName ;
      private string A5SupplierName ;
      private string A10SectorName ;
      private IGxDataStore dsDefault ;
      private string aP1_Name ;
      private int aP2_SupplierId ;
      private int aP3_SectorId ;
      private int aP4_BrandId ;
      private bool aP5_Ordered ;
      private bool aP6_Necesary ;
      private IDataStoreProvider pr_default ;
      private bool[] P00182_A112SupplierActive ;
      private bool[] P00182_A110ProductActive ;
      private bool[] P00182_n110ProductActive ;
      private int[] P00182_A69ProductMiniumStock ;
      private bool[] P00182_n69ProductMiniumStock ;
      private int[] P00182_A17ProductStock ;
      private bool[] P00182_n17ProductStock ;
      private int[] P00182_A9SectorId ;
      private bool[] P00182_n9SectorId ;
      private int[] P00182_A1BrandId ;
      private bool[] P00182_n1BrandId ;
      private int[] P00182_A4SupplierId ;
      private string[] P00182_A16ProductName ;
      private string[] P00182_A55ProductCode ;
      private bool[] P00182_n55ProductCode ;
      private int[] P00182_A15ProductId ;
      private string[] P00182_A2BrandName ;
      private string[] P00182_A5SupplierName ;
      private string[] P00182_A10SectorName ;
      private decimal[] P00182_A85ProductCostPrice ;
      private bool[] P00182_n85ProductCostPrice ;
      private GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> aP7_SDTProductsFiltered ;
      private GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> AV30SDTProductsFiltered ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV28SDTProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1 ;
      private SdtSDTProductsFiltered_SDTProductsFilteredItem AV33SDTProductsFilteredItem ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV29SDTProductsSelectedItem ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV37Context ;
   }

   public class getproductsfiltered__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00182( IGxContext context ,
                                             string AV10Code ,
                                             string AV13Name ,
                                             int AV22SupplierId ,
                                             int AV8BrandId ,
                                             int AV18SectorId ,
                                             bool AV31Necesary ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             int A17ProductStock ,
                                             int A69ProductMiniumStock ,
                                             bool A110ProductActive ,
                                             bool A112SupplierActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T4.[SupplierActive], T1.[ProductActive], T1.[ProductMiniumStock], T1.[ProductStock], T1.[SectorId], T1.[BrandId], T1.[SupplierId], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T3.[BrandName], T4.[SupplierName], T2.[SectorName], T1.[ProductCostPrice] FROM ((([Product] T1 LEFT JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) LEFT JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         AddWhere(sWhereString, "(T4.[SupplierActive] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like '%' + @lV10Code + '%')");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like '%' + @lV13Name + '%')");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV22SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV22SupplierId)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV8BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8BrandId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV18SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV18SectorId)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV31Necesary )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] <= T1.[ProductMiniumStock])");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProductId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00182(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (bool)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP00182;
          prmP00182 = new Object[] {
          new ParDef("@lV10Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV13Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV22SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV8BrandId",GXType.Int32,6,0) ,
          new ParDef("@AV18SectorId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00182", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00182,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((int[]) buf[15])[0] = rslt.getInt(10);
                ((string[]) buf[16])[0] = rslt.getVarchar(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
