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
   public class listproductsfilteredexportexcel : GXProcedure
   {
      public listproductsfilteredexportexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public listproductsfilteredexportexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           int aP1_SupplierId ,
                           int aP2_SectorId ,
                           int aP3_BrandId ,
                           short aP4_StockFrom ,
                           short aP5_StockTo ,
                           short aP6_PriceFrom ,
                           short aP7_PriceTo ,
                           short aP8_Order ,
                           bool aP9_Descending ,
                           ref short aP10_Active ,
                           out string aP11_FileName ,
                           out string aP12_ErrorMessage )
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
         this.AV41Active = aP10_Active;
         this.AV27FileName = "" ;
         this.AV35ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP10_Active=this.AV41Active;
         aP11_FileName=this.AV27FileName;
         aP12_ErrorMessage=this.AV35ErrorMessage;
      }

      public string executeUdp( string aP0_Name ,
                                int aP1_SupplierId ,
                                int aP2_SectorId ,
                                int aP3_BrandId ,
                                short aP4_StockFrom ,
                                short aP5_StockTo ,
                                short aP6_PriceFrom ,
                                short aP7_PriceTo ,
                                short aP8_Order ,
                                bool aP9_Descending ,
                                ref short aP10_Active ,
                                out string aP11_FileName )
      {
         execute(aP0_Name, aP1_SupplierId, aP2_SectorId, aP3_BrandId, aP4_StockFrom, aP5_StockTo, aP6_PriceFrom, aP7_PriceTo, aP8_Order, aP9_Descending, ref aP10_Active, out aP11_FileName, out aP12_ErrorMessage);
         return AV35ErrorMessage ;
      }

      public void executeSubmit( string aP0_Name ,
                                 int aP1_SupplierId ,
                                 int aP2_SectorId ,
                                 int aP3_BrandId ,
                                 short aP4_StockFrom ,
                                 short aP5_StockTo ,
                                 short aP6_PriceFrom ,
                                 short aP7_PriceTo ,
                                 short aP8_Order ,
                                 bool aP9_Descending ,
                                 ref short aP10_Active ,
                                 out string aP11_FileName ,
                                 out string aP12_ErrorMessage )
      {
         listproductsfilteredexportexcel objlistproductsfilteredexportexcel;
         objlistproductsfilteredexportexcel = new listproductsfilteredexportexcel();
         objlistproductsfilteredexportexcel.AV13Name = aP0_Name;
         objlistproductsfilteredexportexcel.AV22SupplierId = aP1_SupplierId;
         objlistproductsfilteredexportexcel.AV18SectorId = aP2_SectorId;
         objlistproductsfilteredexportexcel.AV8BrandId = aP3_BrandId;
         objlistproductsfilteredexportexcel.AV20StockFrom = aP4_StockFrom;
         objlistproductsfilteredexportexcel.AV21StockTo = aP5_StockTo;
         objlistproductsfilteredexportexcel.AV15PriceFrom = aP6_PriceFrom;
         objlistproductsfilteredexportexcel.AV16PriceTo = aP7_PriceTo;
         objlistproductsfilteredexportexcel.AV14Order = aP8_Order;
         objlistproductsfilteredexportexcel.AV12Descending = aP9_Descending;
         objlistproductsfilteredexportexcel.AV41Active = aP10_Active;
         objlistproductsfilteredexportexcel.AV27FileName = "" ;
         objlistproductsfilteredexportexcel.AV35ErrorMessage = "" ;
         objlistproductsfilteredexportexcel.context.SetSubmitInitialConfig(context);
         objlistproductsfilteredexportexcel.initialize();
         Submit( executePrivateCatch,objlistproductsfilteredexportexcel);
         aP10_Active=this.AV41Active;
         aP11_FileName=this.AV27FileName;
         aP12_ErrorMessage=this.AV35ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listproductsfilteredexportexcel)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV39Context, ref  AV40AllOk) ;
         if ( ! AV40AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV38Random = (int)(NumberUtil.Random( )*10000);
         AV27FileName = "ListProducts-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV38Random), 8, 0)) + ".xlsx";
         AV26ExcelDocument.Open(AV27FileName);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV26ExcelDocument.Clear();
         AV34CellRow = 1;
         AV36FirstColumn = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+0, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+0, 1, 1).Text = "Name";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+1, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+1, 1, 1).Text = "Supplier";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+2, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+2, 1, 1).Text = "Brand";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+3, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+3, 1, 1).Text = "Sector";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+4, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+4, 1, 1).Text = "Stock";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+5, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+5, 1, 1).Text = "Cost Price";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+6, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+6, 1, 1).Text = "Retail Price";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+7, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+7, 1, 1).Text = "Wholesale Price";
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+8, 1, 1).Bold = 1;
         AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+8, 1, 1).Text = "Qty. Wholesale";
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
                                              AV41Active ,
                                              A4SupplierId ,
                                              A9SectorId ,
                                              A1BrandId ,
                                              A16ProductName ,
                                              A55ProductCode ,
                                              A17ProductStock ,
                                              A85ProductCostPrice ,
                                              A110ProductActive ,
                                              AV14Order ,
                                              AV12Descending } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV13Name = StringUtil.Concat( StringUtil.RTrim( AV13Name), "%", "");
         lV10Code = StringUtil.Concat( StringUtil.RTrim( AV10Code), "%", "");
         /* Using cursor P00102 */
         pr_default.execute(0, new Object[] {AV22SupplierId, AV18SectorId, AV8BrandId, lV13Name, lV10Code, AV20StockFrom, AV21StockTo, AV15PriceFrom, AV16PriceTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A110ProductActive = P00102_A110ProductActive[0];
            n110ProductActive = P00102_n110ProductActive[0];
            A17ProductStock = P00102_A17ProductStock[0];
            n17ProductStock = P00102_n17ProductStock[0];
            A55ProductCode = P00102_A55ProductCode[0];
            n55ProductCode = P00102_n55ProductCode[0];
            A16ProductName = P00102_A16ProductName[0];
            A1BrandId = P00102_A1BrandId[0];
            n1BrandId = P00102_n1BrandId[0];
            A9SectorId = P00102_A9SectorId[0];
            n9SectorId = P00102_n9SectorId[0];
            A4SupplierId = P00102_A4SupplierId[0];
            A93ProductMiniumQuantityWholesale = P00102_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = P00102_n93ProductMiniumQuantityWholesale[0];
            A28ProductCreatedDate = P00102_A28ProductCreatedDate[0];
            A10SectorName = P00102_A10SectorName[0];
            A2BrandName = P00102_A2BrandName[0];
            A5SupplierName = P00102_A5SupplierName[0];
            A87ProductWholesaleProfit = P00102_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = P00102_n87ProductWholesaleProfit[0];
            A85ProductCostPrice = P00102_A85ProductCostPrice[0];
            n85ProductCostPrice = P00102_n85ProductCostPrice[0];
            A89ProductRetailProfit = P00102_A89ProductRetailProfit[0];
            n89ProductRetailProfit = P00102_n89ProductRetailProfit[0];
            A15ProductId = P00102_A15ProductId[0];
            A2BrandName = P00102_A2BrandName[0];
            A10SectorName = P00102_A10SectorName[0];
            A5SupplierName = P00102_A5SupplierName[0];
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
            AV34CellRow = (int)(AV34CellRow+1);
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+0, 1, 1).Text = A16ProductName;
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+1, 1, 1).Text = A5SupplierName;
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+2, 1, 1).Text = A2BrandName;
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+3, 1, 1).Text = A10SectorName;
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+4, 1, 1).Number = A17ProductStock;
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+5, 1, 1).Number = (double)(A85ProductCostPrice);
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+5, 1, 1).Number = (double)(A90ProductRetailPrice);
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+5, 1, 1).Number = (double)(A88ProductWholesalePrice);
            AV26ExcelDocument.get_Cells(AV34CellRow, AV36FirstColumn+5, 1, 1).Number = A93ProductMiniumQuantityWholesale;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV26ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV26ExcelDocument.Close();
         if ( AV31StorageProvider.GetPrivate(AV27FileName, AV32File, 1, AV33Messages) )
         {
            AV27FileName = AV32File.GetURI();
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV26ExcelDocument.ErrCode != 0 )
         {
            AV27FileName = "";
            AV35ErrorMessage = AV26ExcelDocument.ErrDescription;
            AV26ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
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
         AV27FileName = "";
         AV35ErrorMessage = "";
         AV39Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV26ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV13Name = "";
         lV10Code = "";
         AV10Code = "";
         A16ProductName = "";
         A55ProductCode = "";
         P00102_A110ProductActive = new bool[] {false} ;
         P00102_n110ProductActive = new bool[] {false} ;
         P00102_A17ProductStock = new int[1] ;
         P00102_n17ProductStock = new bool[] {false} ;
         P00102_A55ProductCode = new string[] {""} ;
         P00102_n55ProductCode = new bool[] {false} ;
         P00102_A16ProductName = new string[] {""} ;
         P00102_A1BrandId = new int[1] ;
         P00102_n1BrandId = new bool[] {false} ;
         P00102_A9SectorId = new int[1] ;
         P00102_n9SectorId = new bool[] {false} ;
         P00102_A4SupplierId = new int[1] ;
         P00102_A93ProductMiniumQuantityWholesale = new short[1] ;
         P00102_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         P00102_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P00102_A10SectorName = new string[] {""} ;
         P00102_A2BrandName = new string[] {""} ;
         P00102_A5SupplierName = new string[] {""} ;
         P00102_A87ProductWholesaleProfit = new decimal[1] ;
         P00102_n87ProductWholesaleProfit = new bool[] {false} ;
         P00102_A85ProductCostPrice = new decimal[1] ;
         P00102_n85ProductCostPrice = new bool[] {false} ;
         P00102_A89ProductRetailProfit = new decimal[1] ;
         P00102_n89ProductRetailProfit = new bool[] {false} ;
         P00102_A15ProductId = new int[1] ;
         A28ProductCreatedDate = DateTime.MinValue;
         A10SectorName = "";
         A2BrandName = "";
         A5SupplierName = "";
         AV32File = new GxFile(context.GetPhysicalPath());
         AV33Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV31StorageProvider = new GxStorageProvider();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listproductsfilteredexportexcel__default(),
            new Object[][] {
                new Object[] {
               P00102_A110ProductActive, P00102_n110ProductActive, P00102_A17ProductStock, P00102_n17ProductStock, P00102_A55ProductCode, P00102_n55ProductCode, P00102_A16ProductName, P00102_A1BrandId, P00102_n1BrandId, P00102_A9SectorId,
               P00102_n9SectorId, P00102_A4SupplierId, P00102_A93ProductMiniumQuantityWholesale, P00102_n93ProductMiniumQuantityWholesale, P00102_A28ProductCreatedDate, P00102_A10SectorName, P00102_A2BrandName, P00102_A5SupplierName, P00102_A87ProductWholesaleProfit, P00102_n87ProductWholesaleProfit,
               P00102_A85ProductCostPrice, P00102_n85ProductCostPrice, P00102_A89ProductRetailProfit, P00102_n89ProductRetailProfit, P00102_A15ProductId
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
      private short AV41Active ;
      private short A93ProductMiniumQuantityWholesale ;
      private int AV22SupplierId ;
      private int AV18SectorId ;
      private int AV8BrandId ;
      private int AV38Random ;
      private int AV34CellRow ;
      private int AV36FirstColumn ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A1BrandId ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private decimal A85ProductCostPrice ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private DateTime A28ProductCreatedDate ;
      private bool AV12Descending ;
      private bool AV40AllOk ;
      private bool returnInSub ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n17ProductStock ;
      private bool n55ProductCode ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n87ProductWholesaleProfit ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private string AV13Name ;
      private string AV27FileName ;
      private string AV35ErrorMessage ;
      private string lV13Name ;
      private string lV10Code ;
      private string AV10Code ;
      private string A16ProductName ;
      private string A55ProductCode ;
      private string A10SectorName ;
      private string A2BrandName ;
      private string A5SupplierName ;
      private GxStorageProvider AV31StorageProvider ;
      private IGxDataStore dsDefault ;
      private short aP10_Active ;
      private IDataStoreProvider pr_default ;
      private bool[] P00102_A110ProductActive ;
      private bool[] P00102_n110ProductActive ;
      private int[] P00102_A17ProductStock ;
      private bool[] P00102_n17ProductStock ;
      private string[] P00102_A55ProductCode ;
      private bool[] P00102_n55ProductCode ;
      private string[] P00102_A16ProductName ;
      private int[] P00102_A1BrandId ;
      private bool[] P00102_n1BrandId ;
      private int[] P00102_A9SectorId ;
      private bool[] P00102_n9SectorId ;
      private int[] P00102_A4SupplierId ;
      private short[] P00102_A93ProductMiniumQuantityWholesale ;
      private bool[] P00102_n93ProductMiniumQuantityWholesale ;
      private DateTime[] P00102_A28ProductCreatedDate ;
      private string[] P00102_A10SectorName ;
      private string[] P00102_A2BrandName ;
      private string[] P00102_A5SupplierName ;
      private decimal[] P00102_A87ProductWholesaleProfit ;
      private bool[] P00102_n87ProductWholesaleProfit ;
      private decimal[] P00102_A85ProductCostPrice ;
      private bool[] P00102_n85ProductCostPrice ;
      private decimal[] P00102_A89ProductRetailProfit ;
      private bool[] P00102_n89ProductRetailProfit ;
      private int[] P00102_A15ProductId ;
      private string aP11_FileName ;
      private string aP12_ErrorMessage ;
      private ExcelDocumentI AV26ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV33Messages ;
      private GxFile AV32File ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV39Context ;
   }

   public class listproductsfilteredexportexcel__default : DataStoreHelperBase, IDataStoreHelper
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
                                             short AV41Active ,
                                             int A4SupplierId ,
                                             int A9SectorId ,
                                             int A1BrandId ,
                                             string A16ProductName ,
                                             string A55ProductCode ,
                                             int A17ProductStock ,
                                             decimal A85ProductCostPrice ,
                                             bool A110ProductActive ,
                                             short AV14Order ,
                                             bool AV12Descending )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ProductActive], T1.[ProductStock], T1.[ProductCode], T1.[ProductName], T1.[BrandId], T1.[SectorId], T1.[SupplierId], T1.[ProductMiniumQuantityWholesale], T1.[ProductCreatedDate], T3.[SectorName], T2.[BrandName], T4.[SupplierName], T1.[ProductWholesaleProfit], T1.[ProductCostPrice], T1.[ProductRetailProfit], T1.[ProductId] FROM ((([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         if ( ! (0==AV22SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV22SupplierId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV18SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV18SectorId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV8BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8BrandId)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV13Name)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV10Code)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV20StockFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] >= @AV20StockFrom)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV21StockTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] <= @AV21StockTo)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV15PriceFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] >= @AV15PriceFrom)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV16PriceTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] <= @AV16PriceTo)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV41Active) && ( AV41Active == 1 ) )
         {
            AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         }
         if ( ! (0==AV41Active) && ( AV41Active == 2 ) )
         {
            AddWhere(sWhereString, "(Not T1.[ProductActive] = 1)");
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
            scmdbuf += " ORDER BY T1.[ProductCostPrice]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 6 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCostPrice] DESC";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 9 ) && ! AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCreatedDate]";
         }
         else if ( ! (0==AV14Order) && ( AV14Order == 9 ) && AV12Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCreatedDate] DESC";
         }
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
                     return conditional_P00102(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (decimal)dynConstraints[16] , (bool)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
              new CursorDef("P00102", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00102,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((short[]) buf[12])[0] = rslt.getShort(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((string[]) buf[16])[0] = rslt.getVarchar(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(15);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((int[]) buf[24])[0] = rslt.getInt(16);
                return;
       }
    }

 }

}
