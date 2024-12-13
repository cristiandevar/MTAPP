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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class alistproductsfilteredexportexcel : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new alistproductsfilteredexportexcel().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Upgrades for Version1", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         string aP0_Name = new string(' ',0)  ;
          int aP1_SupplierId ;
          int aP2_SectorId ;
          int aP3_BrandId ;
          short aP4_StockFrom ;
          short aP5_StockTo ;
          short aP6_PriceFrom ;
          short aP7_PriceTo ;
          short aP8_Order ;
         bool aP9_Descending = new bool()  ;
         if ( 0 < args.Length )
         {
            aP0_Name=((string)(args[0]));
         }
         else
         {
            aP0_Name="";
         }
         if ( 1 < args.Length )
         {
            aP1_SupplierId=((int)(NumberUtil.Val( (string)(args[1]), ".")));
         }
         else
         {
            aP1_SupplierId=0;
         }
         if ( 2 < args.Length )
         {
            aP2_SectorId=((int)(NumberUtil.Val( (string)(args[2]), ".")));
         }
         else
         {
            aP2_SectorId=0;
         }
         if ( 3 < args.Length )
         {
            aP3_BrandId=((int)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_BrandId=0;
         }
         if ( 4 < args.Length )
         {
            aP4_StockFrom=((short)(NumberUtil.Val( (string)(args[4]), ".")));
         }
         else
         {
            aP4_StockFrom=0;
         }
         if ( 5 < args.Length )
         {
            aP5_StockTo=((short)(NumberUtil.Val( (string)(args[5]), ".")));
         }
         else
         {
            aP5_StockTo=0;
         }
         if ( 6 < args.Length )
         {
            aP6_PriceFrom=((short)(NumberUtil.Val( (string)(args[6]), ".")));
         }
         else
         {
            aP6_PriceFrom=0;
         }
         if ( 7 < args.Length )
         {
            aP7_PriceTo=((short)(NumberUtil.Val( (string)(args[7]), ".")));
         }
         else
         {
            aP7_PriceTo=0;
         }
         if ( 8 < args.Length )
         {
            aP8_Order=((short)(NumberUtil.Val( (string)(args[8]), ".")));
         }
         else
         {
            aP8_Order=0;
         }
         if ( 9 < args.Length )
         {
            aP9_Descending=((bool)(BooleanUtil.Val( (string)(args[9]))));
         }
         else
         {
            aP9_Descending=false;
         }
         execute(aP0_Name, ref aP1_SupplierId, ref aP2_SectorId, ref aP3_BrandId, ref aP4_StockFrom, ref aP5_StockTo, ref aP6_PriceFrom, ref aP7_PriceTo, ref aP8_Order, ref aP9_Descending);
         return GX.GXRuntime.ExitCode ;
      }

      public alistproductsfilteredexportexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public alistproductsfilteredexportexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           ref int aP1_SupplierId ,
                           ref int aP2_SectorId ,
                           ref int aP3_BrandId ,
                           ref short aP4_StockFrom ,
                           ref short aP5_StockTo ,
                           ref short aP6_PriceFrom ,
                           ref short aP7_PriceTo ,
                           ref short aP8_Order ,
                           ref bool aP9_Descending )
      {
         this.AV13Name = aP0_Name;
         this.AV22SupplierId = aP1_SupplierId;
         this.AV18SectorId = aP2_SectorId;
         this.AV8BrandId = aP3_BrandId;
         this.AV20StockFrom = aP4_StockFrom;
         this.AV21StockTo = aP5_StockTo;
         this.AV15PriceFrom = aP6_PriceFrom;
         this.AV16PriceTo = aP7_PriceTo;
         this.AV14Order = aP8_Order;
         this.AV12Descending = aP9_Descending;
         initialize();
         executePrivate();
         aP1_SupplierId=this.AV22SupplierId;
         aP2_SectorId=this.AV18SectorId;
         aP3_BrandId=this.AV8BrandId;
         aP4_StockFrom=this.AV20StockFrom;
         aP5_StockTo=this.AV21StockTo;
         aP6_PriceFrom=this.AV15PriceFrom;
         aP7_PriceTo=this.AV16PriceTo;
         aP8_Order=this.AV14Order;
         aP9_Descending=this.AV12Descending;
      }

      public bool executeUdp( string aP0_Name ,
                              ref int aP1_SupplierId ,
                              ref int aP2_SectorId ,
                              ref int aP3_BrandId ,
                              ref short aP4_StockFrom ,
                              ref short aP5_StockTo ,
                              ref short aP6_PriceFrom ,
                              ref short aP7_PriceTo ,
                              ref short aP8_Order )
      {
         execute(aP0_Name, ref aP1_SupplierId, ref aP2_SectorId, ref aP3_BrandId, ref aP4_StockFrom, ref aP5_StockTo, ref aP6_PriceFrom, ref aP7_PriceTo, ref aP8_Order, ref aP9_Descending);
         return AV12Descending ;
      }

      public void executeSubmit( string aP0_Name ,
                                 ref int aP1_SupplierId ,
                                 ref int aP2_SectorId ,
                                 ref int aP3_BrandId ,
                                 ref short aP4_StockFrom ,
                                 ref short aP5_StockTo ,
                                 ref short aP6_PriceFrom ,
                                 ref short aP7_PriceTo ,
                                 ref short aP8_Order ,
                                 ref bool aP9_Descending )
      {
         alistproductsfilteredexportexcel objalistproductsfilteredexportexcel;
         objalistproductsfilteredexportexcel = new alistproductsfilteredexportexcel();
         objalistproductsfilteredexportexcel.AV13Name = aP0_Name;
         objalistproductsfilteredexportexcel.AV22SupplierId = aP1_SupplierId;
         objalistproductsfilteredexportexcel.AV18SectorId = aP2_SectorId;
         objalistproductsfilteredexportexcel.AV8BrandId = aP3_BrandId;
         objalistproductsfilteredexportexcel.AV20StockFrom = aP4_StockFrom;
         objalistproductsfilteredexportexcel.AV21StockTo = aP5_StockTo;
         objalistproductsfilteredexportexcel.AV15PriceFrom = aP6_PriceFrom;
         objalistproductsfilteredexportexcel.AV16PriceTo = aP7_PriceTo;
         objalistproductsfilteredexportexcel.AV14Order = aP8_Order;
         objalistproductsfilteredexportexcel.AV12Descending = aP9_Descending;
         objalistproductsfilteredexportexcel.context.SetSubmitInitialConfig(context);
         objalistproductsfilteredexportexcel.initialize();
         Submit( executePrivateCatch,objalistproductsfilteredexportexcel);
         aP1_SupplierId=this.AV22SupplierId;
         aP2_SectorId=this.AV18SectorId;
         aP3_BrandId=this.AV8BrandId;
         aP4_StockFrom=this.AV20StockFrom;
         aP5_StockTo=this.AV21StockTo;
         aP6_PriceFrom=this.AV15PriceFrom;
         aP7_PriceTo=this.AV16PriceTo;
         aP8_Order=this.AV14Order;
         aP9_Descending=this.AV12Descending;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistproductsfilteredexportexcel)stateInfo).executePrivate();
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
         AV27FileName = "Products.xlsx";
         AV26ExcelDocument.Open(AV27FileName);
         if ( AV26ExcelDocument.ErrCode != 0 )
         {
            GX_msglist.addItem(AV26ExcelDocument.ErrDescription);
         }
         else
         {
            AV26ExcelDocument.Clear();
            AV26ExcelDocument.get_Cells(1, 1, 1, 1).Text = "Products List";
            AV26ExcelDocument.get_Cells(1, 1, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(1, 1, 1, 1).Color = GXUtil.RGB( 0, 0, 255);
            AV26ExcelDocument.get_Cells(1, 1, 1, 1).Size = 10;
            AV26ExcelDocument.get_Cells(2, 1, 1, 1).Text = "Name";
            AV26ExcelDocument.get_Cells(2, 1, 1, 1).Italic = 1;
            AV26ExcelDocument.get_Cells(2, 1, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(2, 2, 1, 1).Text = "Supplier";
            AV26ExcelDocument.get_Cells(2, 2, 1, 1).Italic = 1;
            AV26ExcelDocument.get_Cells(2, 2, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(2, 3, 1, 1).Text = "Brand";
            AV26ExcelDocument.get_Cells(2, 3, 1, 1).Italic = 1;
            AV26ExcelDocument.get_Cells(2, 3, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(2, 4, 1, 1).Text = "Sector";
            AV26ExcelDocument.get_Cells(2, 4, 1, 1).Italic = 1;
            AV26ExcelDocument.get_Cells(2, 4, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(2, 5, 1, 1).Text = "Stock";
            AV26ExcelDocument.get_Cells(2, 5, 1, 1).Italic = 1;
            AV26ExcelDocument.get_Cells(2, 5, 1, 1).Bold = 1;
            AV26ExcelDocument.get_Cells(2, 6, 1, 1).Text = "Price";
            AV26ExcelDocument.get_Cells(2, 6, 1, 1).Italic = 1;
            AV26ExcelDocument.get_Cells(2, 6, 1, 1).Bold = 1;
            AV28row = 4;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV22SupplierId ,
                                                 AV18SectorId ,
                                                 AV8BrandId ,
                                                 AV13Name ,
                                                 AV10Code ,
                                                 AV20StockFrom ,
                                                 AV21StockTo ,
                                                 AV15PriceFrom ,
                                                 AV16PriceTo ,
                                                 A4SupplierId ,
                                                 A9SectorId ,
                                                 A1BrandId ,
                                                 A16ProductName ,
                                                 A55ProductCode ,
                                                 A17ProductStock ,
                                                 A18ProductPrice ,
                                                 AV14Order ,
                                                 AV12Descending } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV13Name = StringUtil.Concat( StringUtil.RTrim( AV13Name), "%", "");
            lV10Code = StringUtil.Concat( StringUtil.RTrim( AV10Code), "%", "");
            /* Using cursor P00102 */
            pr_default.execute(0, new Object[] {AV22SupplierId, AV18SectorId, AV8BrandId, lV13Name, lV10Code, AV20StockFrom, AV21StockTo, AV15PriceFrom, AV16PriceTo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A18ProductPrice = P00102_A18ProductPrice[0];
               A17ProductStock = P00102_A17ProductStock[0];
               A55ProductCode = P00102_A55ProductCode[0];
               n55ProductCode = P00102_n55ProductCode[0];
               A16ProductName = P00102_A16ProductName[0];
               A1BrandId = P00102_A1BrandId[0];
               A9SectorId = P00102_A9SectorId[0];
               A4SupplierId = P00102_A4SupplierId[0];
               A28ProductCreatedDate = P00102_A28ProductCreatedDate[0];
               A10SectorName = P00102_A10SectorName[0];
               A2BrandName = P00102_A2BrandName[0];
               A5SupplierName = P00102_A5SupplierName[0];
               A15ProductId = P00102_A15ProductId[0];
               A2BrandName = P00102_A2BrandName[0];
               A10SectorName = P00102_A10SectorName[0];
               A5SupplierName = P00102_A5SupplierName[0];
               AV26ExcelDocument.get_Cells(AV28row, 1, 1, 1).Text = A16ProductName;
               AV26ExcelDocument.get_Cells(AV28row, 1, 1, 1).Color = GXUtil.RGB( 0, 0, 255);
               AV26ExcelDocument.get_Cells(AV28row, 2, 1, 1).Text = A5SupplierName;
               AV26ExcelDocument.get_Cells(AV28row, 2, 1, 1).Color = GXUtil.RGB( 0, 0, 255);
               AV26ExcelDocument.get_Cells(AV28row, 3, 1, 1).Text = A2BrandName;
               AV26ExcelDocument.get_Cells(AV28row, 3, 1, 1).Color = GXUtil.RGB( 0, 0, 255);
               AV26ExcelDocument.get_Cells(AV28row, 4, 1, 1).Text = A10SectorName;
               AV26ExcelDocument.get_Cells(AV28row, 4, 1, 1).Color = GXUtil.RGB( 0, 0, 255);
               AV26ExcelDocument.get_Cells(AV28row, 5, 1, 1).Number = A17ProductStock;
               AV26ExcelDocument.get_Cells(AV28row, 5, 1, 1).Color = GXUtil.RGB( 0, 0, 255);
               AV26ExcelDocument.get_Cells(AV28row, 6, 1, 1).Number = (double)(A18ProductPrice);
               AV26ExcelDocument.get_Cells(AV28row, 6, 1, 1).Color = GXUtil.RGB( 0, 0, 255);
               AV28row = (short)(AV28row+1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV26ExcelDocument.Save();
            AV26ExcelDocument.Close();
         }
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
         AV27FileName = "";
         AV26ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV13Name = "";
         lV10Code = "";
         AV10Code = "";
         A16ProductName = "";
         A55ProductCode = "";
         P00102_A18ProductPrice = new decimal[1] ;
         P00102_A17ProductStock = new int[1] ;
         P00102_A55ProductCode = new string[] {""} ;
         P00102_n55ProductCode = new bool[] {false} ;
         P00102_A16ProductName = new string[] {""} ;
         P00102_A1BrandId = new int[1] ;
         P00102_A9SectorId = new int[1] ;
         P00102_A4SupplierId = new int[1] ;
         P00102_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P00102_A10SectorName = new string[] {""} ;
         P00102_A2BrandName = new string[] {""} ;
         P00102_A5SupplierName = new string[] {""} ;
         P00102_A15ProductId = new int[1] ;
         A28ProductCreatedDate = DateTime.MinValue;
         A10SectorName = "";
         A2BrandName = "";
         A5SupplierName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistproductsfilteredexportexcel__default(),
            new Object[][] {
                new Object[] {
               P00102_A18ProductPrice, P00102_A17ProductStock, P00102_A55ProductCode, P00102_n55ProductCode, P00102_A16ProductName, P00102_A1BrandId, P00102_A9SectorId, P00102_A4SupplierId, P00102_A28ProductCreatedDate, P00102_A10SectorName,
               P00102_A2BrandName, P00102_A5SupplierName, P00102_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV20StockFrom ;
      private short AV21StockTo ;
      private short AV15PriceFrom ;
      private short AV16PriceTo ;
      private short AV14Order ;
      private short AV28row ;
      private int AV22SupplierId ;
      private int AV18SectorId ;
      private int AV8BrandId ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A1BrandId ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private decimal A18ProductPrice ;
      private string scmdbuf ;
      private DateTime A28ProductCreatedDate ;
      private bool AV12Descending ;
      private bool n55ProductCode ;
      private string AV13Name ;
      private string AV27FileName ;
      private string lV13Name ;
      private string lV10Code ;
      private string AV10Code ;
      private string A16ProductName ;
      private string A55ProductCode ;
      private string A10SectorName ;
      private string A2BrandName ;
      private string A5SupplierName ;
      private IGxDataStore dsDefault ;
      private int aP1_SupplierId ;
      private int aP2_SectorId ;
      private int aP3_BrandId ;
      private short aP4_StockFrom ;
      private short aP5_StockTo ;
      private short aP6_PriceFrom ;
      private short aP7_PriceTo ;
      private short aP8_Order ;
      private bool aP9_Descending ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00102_A18ProductPrice ;
      private int[] P00102_A17ProductStock ;
      private string[] P00102_A55ProductCode ;
      private bool[] P00102_n55ProductCode ;
      private string[] P00102_A16ProductName ;
      private int[] P00102_A1BrandId ;
      private int[] P00102_A9SectorId ;
      private int[] P00102_A4SupplierId ;
      private DateTime[] P00102_A28ProductCreatedDate ;
      private string[] P00102_A10SectorName ;
      private string[] P00102_A2BrandName ;
      private string[] P00102_A5SupplierName ;
      private int[] P00102_A15ProductId ;
      private ExcelDocumentI AV26ExcelDocument ;
   }

   public class alistproductsfilteredexportexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00102( IGxContext context ,
                                             int AV22SupplierId ,
                                             int AV18SectorId ,
                                             int AV8BrandId ,
                                             string AV13Name ,
                                             string AV10Code ,
                                             short AV20StockFrom ,
                                             short AV21StockTo ,
                                             short AV15PriceFrom ,
                                             short AV16PriceTo ,
                                             int A4SupplierId ,
                                             int A9SectorId ,
                                             int A1BrandId ,
                                             string A16ProductName ,
                                             string A55ProductCode ,
                                             int A17ProductStock ,
                                             decimal A18ProductPrice ,
                                             short AV14Order ,
                                             bool AV12Descending )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProductPrice], T1.[ProductStock], T1.[ProductCode], T1.[ProductName], T1.[BrandId], T1.[SectorId], T1.[SupplierId], T1.[ProductCreatedDate], T3.[SectorName], T2.[BrandName], T4.[SupplierName], T1.[ProductId] FROM ((([Product] T1 INNER JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         if ( ! (0==AV22SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV22SupplierId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV18SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV18SectorId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8BrandId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV13Name)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV10Code)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV20StockFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] >= @AV20StockFrom)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV21StockTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] <= @AV21StockTo)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV15PriceFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductPrice] >= @AV15PriceFrom)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV16PriceTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductPrice] <= @AV16PriceTo)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( ! (0==AV14Order) && ( AV14Order == 1 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductName]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 1 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductName] DESC";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 2 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T4.[SupplierName]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 2 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T4.[SupplierName] DESC";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 3 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T2.[BrandName]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 3 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T2.[BrandName] DESC";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 4 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T3.[SectorName]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 4 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T3.[SectorName] DESC";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 5 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductStock]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 5 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductStock] DESC";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 6 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductPrice]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 6 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductPrice] DESC";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 7 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCreatedDate]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 7 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCreatedDate] DESC";
         }
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
                     return conditional_P00102(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (decimal)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmP00102;
          prmP00102 = new Object[] {
          new ParDef("@AV22SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV18SectorId",GXType.Int32,6,0) ,
          new ParDef("@AV8BrandId",GXType.Int32,6,0) ,
          new ParDef("@lV13Name",GXType.NVarChar,60,0) ,
          new ParDef("@lV10Code",GXType.NVarChar,100,0) ,
          new ParDef("@AV20StockFrom",GXType.Int16,4,0) ,
          new ParDef("@AV21StockTo",GXType.Int16,4,0) ,
          new ParDef("@AV15PriceFrom",GXType.Int16,4,0) ,
          new ParDef("@AV16PriceTo",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00102", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00102,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                return;
       }
    }

 }

}
