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
   public class invoiceregistergetproductsfiltered : GXProcedure
   {
      public invoiceregistergetproductsfiltered( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoiceregistergetproductsfiltered( IGxContext context )
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
                           out GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> aP5_SDTProductsFiltered )
      {
         this.AV10Code = aP0_Code;
         this.AV13Name = aP1_Name;
         this.AV22SupplierId = aP2_SupplierId;
         this.AV18SectorId = aP3_SectorId;
         this.AV8BrandId = aP4_BrandId;
         this.AV29SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP1_Name=this.AV13Name;
         aP2_SupplierId=this.AV22SupplierId;
         aP3_SectorId=this.AV18SectorId;
         aP4_BrandId=this.AV8BrandId;
         aP5_SDTProductsFiltered=this.AV29SDTProductsFiltered;
      }

      public GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> executeUdp( string aP0_Code ,
                                                                                          ref string aP1_Name ,
                                                                                          ref int aP2_SupplierId ,
                                                                                          ref int aP3_SectorId ,
                                                                                          ref int aP4_BrandId )
      {
         execute(aP0_Code, ref aP1_Name, ref aP2_SupplierId, ref aP3_SectorId, ref aP4_BrandId, out aP5_SDTProductsFiltered);
         return AV29SDTProductsFiltered ;
      }

      public void executeSubmit( string aP0_Code ,
                                 ref string aP1_Name ,
                                 ref int aP2_SupplierId ,
                                 ref int aP3_SectorId ,
                                 ref int aP4_BrandId ,
                                 out GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> aP5_SDTProductsFiltered )
      {
         invoiceregistergetproductsfiltered objinvoiceregistergetproductsfiltered;
         objinvoiceregistergetproductsfiltered = new invoiceregistergetproductsfiltered();
         objinvoiceregistergetproductsfiltered.AV10Code = aP0_Code;
         objinvoiceregistergetproductsfiltered.AV13Name = aP1_Name;
         objinvoiceregistergetproductsfiltered.AV22SupplierId = aP2_SupplierId;
         objinvoiceregistergetproductsfiltered.AV18SectorId = aP3_SectorId;
         objinvoiceregistergetproductsfiltered.AV8BrandId = aP4_BrandId;
         objinvoiceregistergetproductsfiltered.AV29SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB") ;
         objinvoiceregistergetproductsfiltered.context.SetSubmitInitialConfig(context);
         objinvoiceregistergetproductsfiltered.initialize();
         Submit( executePrivateCatch,objinvoiceregistergetproductsfiltered);
         aP1_Name=this.AV13Name;
         aP2_SupplierId=this.AV22SupplierId;
         aP3_SectorId=this.AV18SectorId;
         aP4_BrandId=this.AV8BrandId;
         aP5_SDTProductsFiltered=this.AV29SDTProductsFiltered;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((invoiceregistergetproductsfiltered)stateInfo).executePrivate();
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
         new checkauthentication(context ).execute( out  AV36Context) ;
         AV29SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10Code ,
                                              AV13Name ,
                                              AV22SupplierId ,
                                              AV8BrandId ,
                                              AV18SectorId ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A4SupplierId ,
                                              A1BrandId ,
                                              A9SectorId ,
                                              A17ProductStock ,
                                              A110ProductActive ,
                                              A112SupplierActive } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV10Code = StringUtil.Concat( StringUtil.RTrim( AV10Code), "%", "");
         lV13Name = StringUtil.Concat( StringUtil.RTrim( AV13Name), "%", "");
         /* Using cursor P002Q2 */
         pr_default.execute(0, new Object[] {lV10Code, lV13Name, AV22SupplierId, AV8BrandId, AV18SectorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112SupplierActive = P002Q2_A112SupplierActive[0];
            A110ProductActive = P002Q2_A110ProductActive[0];
            n110ProductActive = P002Q2_n110ProductActive[0];
            A17ProductStock = P002Q2_A17ProductStock[0];
            n17ProductStock = P002Q2_n17ProductStock[0];
            A9SectorId = P002Q2_A9SectorId[0];
            n9SectorId = P002Q2_n9SectorId[0];
            A1BrandId = P002Q2_A1BrandId[0];
            n1BrandId = P002Q2_n1BrandId[0];
            A4SupplierId = P002Q2_A4SupplierId[0];
            A16ProductName = P002Q2_A16ProductName[0];
            A55ProductCode = P002Q2_A55ProductCode[0];
            n55ProductCode = P002Q2_n55ProductCode[0];
            A15ProductId = P002Q2_A15ProductId[0];
            A2BrandName = P002Q2_A2BrandName[0];
            A5SupplierName = P002Q2_A5SupplierName[0];
            A10SectorName = P002Q2_A10SectorName[0];
            A69ProductMiniumStock = P002Q2_A69ProductMiniumStock[0];
            n69ProductMiniumStock = P002Q2_n69ProductMiniumStock[0];
            A93ProductMiniumQuantityWholesale = P002Q2_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = P002Q2_n93ProductMiniumQuantityWholesale[0];
            A87ProductWholesaleProfit = P002Q2_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = P002Q2_n87ProductWholesaleProfit[0];
            A85ProductCostPrice = P002Q2_A85ProductCostPrice[0];
            n85ProductCostPrice = P002Q2_n85ProductCostPrice[0];
            A89ProductRetailProfit = P002Q2_A89ProductRetailProfit[0];
            n89ProductRetailProfit = P002Q2_n89ProductRetailProfit[0];
            A10SectorName = P002Q2_A10SectorName[0];
            A2BrandName = P002Q2_A2BrandName[0];
            A112SupplierActive = P002Q2_A112SupplierActive[0];
            A5SupplierName = P002Q2_A5SupplierName[0];
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
            AV26ProductId = A15ProductId;
            AV34AllOk = true;
            AV41Messages = "";
            if ( AV34AllOk )
            {
               AV40ProductCode = A55ProductCode;
               AV39PositionCodeAdded = 0;
               /* Execute user subroutine: 'CODEWASADDED' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! AV37CodeWasAdded )
               {
                  AV32SDTProductsFilteredItem = new SdtSDTProductsFiltered_SDTProductsFilteredItem(context);
                  AV32SDTProductsFilteredItem.gxTpr_Id = A15ProductId;
                  AV32SDTProductsFilteredItem.gxTpr_Name = A16ProductName;
                  AV32SDTProductsFilteredItem.gxTpr_Code = A55ProductCode;
                  AV32SDTProductsFilteredItem.gxTpr_Brand = A2BrandName;
                  AV32SDTProductsFilteredItem.gxTpr_Supplier = A5SupplierName;
                  AV32SDTProductsFilteredItem.gxTpr_Sector = A10SectorName;
                  AV32SDTProductsFilteredItem.gxTpr_Stock = A17ProductStock;
                  AV32SDTProductsFilteredItem.gxTpr_Miniumstock = A69ProductMiniumStock;
                  AV32SDTProductsFilteredItem.gxTpr_Costprice = A85ProductCostPrice;
                  AV32SDTProductsFilteredItem.gxTpr_Retailprice = A90ProductRetailPrice;
                  AV32SDTProductsFilteredItem.gxTpr_Wholesaleprice = A88ProductWholesalePrice;
                  AV32SDTProductsFilteredItem.gxTpr_Miniumquantitywholesale = A93ProductMiniumQuantityWholesale;
                  AV29SDTProductsFiltered.Add(AV32SDTProductsFilteredItem, 0);
               }
               else
               {
                  AV32SDTProductsFilteredItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV29SDTProductsFiltered.Item(AV39PositionCodeAdded));
                  AV32SDTProductsFilteredItem.gxTpr_Stock = (int)(AV32SDTProductsFilteredItem.gxTpr_Stock+A17ProductStock);
                  AV32SDTProductsFilteredItem.gxTpr_Supplier = "";
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CODEWASADDED' Routine */
         returnInSub = false;
         AV37CodeWasAdded = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40ProductCode)) )
         {
            AV39PositionCodeAdded = 1;
            AV45GXV1 = 1;
            while ( AV45GXV1 <= AV29SDTProductsFiltered.Count )
            {
               AV32SDTProductsFilteredItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV29SDTProductsFiltered.Item(AV45GXV1));
               if ( StringUtil.StrCmp(AV32SDTProductsFilteredItem.gxTpr_Code, AV40ProductCode) == 0 )
               {
                  AV37CodeWasAdded = true;
                  if (true) break;
               }
               AV39PositionCodeAdded = (short)(AV39PositionCodeAdded+1);
               AV45GXV1 = (int)(AV45GXV1+1);
            }
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
         AV29SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         AV36Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         lV10Code = "";
         lV13Name = "";
         A55ProductCode = "";
         A16ProductName = "";
         P002Q2_A112SupplierActive = new bool[] {false} ;
         P002Q2_A110ProductActive = new bool[] {false} ;
         P002Q2_n110ProductActive = new bool[] {false} ;
         P002Q2_A17ProductStock = new int[1] ;
         P002Q2_n17ProductStock = new bool[] {false} ;
         P002Q2_A9SectorId = new int[1] ;
         P002Q2_n9SectorId = new bool[] {false} ;
         P002Q2_A1BrandId = new int[1] ;
         P002Q2_n1BrandId = new bool[] {false} ;
         P002Q2_A4SupplierId = new int[1] ;
         P002Q2_A16ProductName = new string[] {""} ;
         P002Q2_A55ProductCode = new string[] {""} ;
         P002Q2_n55ProductCode = new bool[] {false} ;
         P002Q2_A15ProductId = new int[1] ;
         P002Q2_A2BrandName = new string[] {""} ;
         P002Q2_A5SupplierName = new string[] {""} ;
         P002Q2_A10SectorName = new string[] {""} ;
         P002Q2_A69ProductMiniumStock = new int[1] ;
         P002Q2_n69ProductMiniumStock = new bool[] {false} ;
         P002Q2_A93ProductMiniumQuantityWholesale = new short[1] ;
         P002Q2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         P002Q2_A87ProductWholesaleProfit = new decimal[1] ;
         P002Q2_n87ProductWholesaleProfit = new bool[] {false} ;
         P002Q2_A85ProductCostPrice = new decimal[1] ;
         P002Q2_n85ProductCostPrice = new bool[] {false} ;
         P002Q2_A89ProductRetailProfit = new decimal[1] ;
         P002Q2_n89ProductRetailProfit = new bool[] {false} ;
         A2BrandName = "";
         A5SupplierName = "";
         A10SectorName = "";
         AV41Messages = "";
         AV40ProductCode = "";
         AV32SDTProductsFilteredItem = new SdtSDTProductsFiltered_SDTProductsFilteredItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoiceregistergetproductsfiltered__default(),
            new Object[][] {
                new Object[] {
               P002Q2_A112SupplierActive, P002Q2_A110ProductActive, P002Q2_n110ProductActive, P002Q2_A17ProductStock, P002Q2_n17ProductStock, P002Q2_A9SectorId, P002Q2_n9SectorId, P002Q2_A1BrandId, P002Q2_n1BrandId, P002Q2_A4SupplierId,
               P002Q2_A16ProductName, P002Q2_A55ProductCode, P002Q2_n55ProductCode, P002Q2_A15ProductId, P002Q2_A2BrandName, P002Q2_A5SupplierName, P002Q2_A10SectorName, P002Q2_A69ProductMiniumStock, P002Q2_n69ProductMiniumStock, P002Q2_A93ProductMiniumQuantityWholesale,
               P002Q2_n93ProductMiniumQuantityWholesale, P002Q2_A87ProductWholesaleProfit, P002Q2_n87ProductWholesaleProfit, P002Q2_A85ProductCostPrice, P002Q2_n85ProductCostPrice, P002Q2_A89ProductRetailProfit, P002Q2_n89ProductRetailProfit
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A93ProductMiniumQuantityWholesale ;
      private short AV39PositionCodeAdded ;
      private int AV22SupplierId ;
      private int AV18SectorId ;
      private int AV8BrandId ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private int A69ProductMiniumStock ;
      private int AV26ProductId ;
      private int AV45GXV1 ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private bool A110ProductActive ;
      private bool A112SupplierActive ;
      private bool n110ProductActive ;
      private bool n17ProductStock ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool n55ProductCode ;
      private bool n69ProductMiniumStock ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n87ProductWholesaleProfit ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private bool AV34AllOk ;
      private bool returnInSub ;
      private bool AV37CodeWasAdded ;
      private string AV10Code ;
      private string AV13Name ;
      private string lV10Code ;
      private string lV13Name ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A2BrandName ;
      private string A5SupplierName ;
      private string A10SectorName ;
      private string AV41Messages ;
      private string AV40ProductCode ;
      private IGxDataStore dsDefault ;
      private string aP1_Name ;
      private int aP2_SupplierId ;
      private int aP3_SectorId ;
      private int aP4_BrandId ;
      private IDataStoreProvider pr_default ;
      private bool[] P002Q2_A112SupplierActive ;
      private bool[] P002Q2_A110ProductActive ;
      private bool[] P002Q2_n110ProductActive ;
      private int[] P002Q2_A17ProductStock ;
      private bool[] P002Q2_n17ProductStock ;
      private int[] P002Q2_A9SectorId ;
      private bool[] P002Q2_n9SectorId ;
      private int[] P002Q2_A1BrandId ;
      private bool[] P002Q2_n1BrandId ;
      private int[] P002Q2_A4SupplierId ;
      private string[] P002Q2_A16ProductName ;
      private string[] P002Q2_A55ProductCode ;
      private bool[] P002Q2_n55ProductCode ;
      private int[] P002Q2_A15ProductId ;
      private string[] P002Q2_A2BrandName ;
      private string[] P002Q2_A5SupplierName ;
      private string[] P002Q2_A10SectorName ;
      private int[] P002Q2_A69ProductMiniumStock ;
      private bool[] P002Q2_n69ProductMiniumStock ;
      private short[] P002Q2_A93ProductMiniumQuantityWholesale ;
      private bool[] P002Q2_n93ProductMiniumQuantityWholesale ;
      private decimal[] P002Q2_A87ProductWholesaleProfit ;
      private bool[] P002Q2_n87ProductWholesaleProfit ;
      private decimal[] P002Q2_A85ProductCostPrice ;
      private bool[] P002Q2_n85ProductCostPrice ;
      private decimal[] P002Q2_A89ProductRetailProfit ;
      private bool[] P002Q2_n89ProductRetailProfit ;
      private GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> aP5_SDTProductsFiltered ;
      private GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> AV29SDTProductsFiltered ;
      private SdtSDTProductsFiltered_SDTProductsFilteredItem AV32SDTProductsFilteredItem ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV36Context ;
   }

   public class invoiceregistergetproductsfiltered__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002Q2( IGxContext context ,
                                             string AV10Code ,
                                             string AV13Name ,
                                             int AV22SupplierId ,
                                             int AV8BrandId ,
                                             int AV18SectorId ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             int A17ProductStock ,
                                             bool A110ProductActive ,
                                             bool A112SupplierActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T4.[SupplierActive], T1.[ProductActive], T1.[ProductStock], T1.[SectorId], T1.[BrandId], T1.[SupplierId], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T3.[BrandName], T4.[SupplierName], T2.[SectorName], T1.[ProductMiniumStock], T1.[ProductMiniumQuantityWholesale], T1.[ProductWholesaleProfit], T1.[ProductCostPrice], T1.[ProductRetailProfit] FROM ((([Product] T1 LEFT JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) LEFT JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         AddWhere(sWhereString, "(T1.[ProductStock] > 0)");
         AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         AddWhere(sWhereString, "(T4.[SupplierActive] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV10Code)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like '%' + @lV13Name + '%')");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV22SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV22SupplierId)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV8BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8BrandId)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV18SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV18SectorId)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProductId]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002Q2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] );
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
          Object[] prmP002Q2;
          prmP002Q2 = new Object[] {
          new ParDef("@lV10Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV13Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV22SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV8BrandId",GXType.Int32,6,0) ,
          new ParDef("@AV18SectorId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((int[]) buf[13])[0] = rslt.getInt(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((string[]) buf[15])[0] = rslt.getVarchar(11);
                ((string[]) buf[16])[0] = rslt.getVarchar(12);
                ((int[]) buf[17])[0] = rslt.getInt(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((short[]) buf[19])[0] = rslt.getShort(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(16);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
