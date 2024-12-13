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
   public class exportsectorproductwc : GXProcedure
   {
      public exportsectorproductwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public exportsectorproductwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SectorId ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV18SectorId = aP0_SectorId;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( int aP0_SectorId ,
                                out string aP1_Filename )
      {
         execute(aP0_SectorId, out aP1_Filename, out aP2_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( int aP0_SectorId ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         exportsectorproductwc objexportsectorproductwc;
         objexportsectorproductwc = new exportsectorproductwc();
         objexportsectorproductwc.AV18SectorId = aP0_SectorId;
         objexportsectorproductwc.AV10Filename = "" ;
         objexportsectorproductwc.AV11ErrorMessage = "" ;
         objexportsectorproductwc.context.SetSubmitInitialConfig(context);
         objexportsectorproductwc.initialize();
         Submit( executePrivateCatch,objexportsectorproductwc);
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportsectorproductwc)stateInfo).executePrivate();
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
         AV14Random = (int)(NumberUtil.Random( )*10000);
         AV10Filename = "ExportSectorProductWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
         AV9ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV9ExcelDocument.Clear();
         AV12CellRow = 1;
         AV13FirstColumn = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Code";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = "Name";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = "Stock";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = "Minium Stock";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "Cost Price";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = "Retail Profit";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = "Retail Price";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = "Wholesale Profit";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Text = "Wholesale Price";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Text = "Quantity Wholesale";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+10, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+10, 1, 1).Text = "Brand";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+11, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+11, 1, 1).Text = "Supplier";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+12, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+12, 1, 1).Text = "State";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+13, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+13, 1, 1).Text = "Description";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+14, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+14, 1, 1).Text = "Created";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+15, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+15, 1, 1).Text = "Modified";
         /* Using cursor P001T2 */
         pr_default.execute(0, new Object[] {AV18SectorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1BrandId = P001T2_A1BrandId[0];
            n1BrandId = P001T2_n1BrandId[0];
            A4SupplierId = P001T2_A4SupplierId[0];
            A9SectorId = P001T2_A9SectorId[0];
            n9SectorId = P001T2_n9SectorId[0];
            A55ProductCode = P001T2_A55ProductCode[0];
            n55ProductCode = P001T2_n55ProductCode[0];
            A16ProductName = P001T2_A16ProductName[0];
            A17ProductStock = P001T2_A17ProductStock[0];
            n17ProductStock = P001T2_n17ProductStock[0];
            A69ProductMiniumStock = P001T2_A69ProductMiniumStock[0];
            n69ProductMiniumStock = P001T2_n69ProductMiniumStock[0];
            A93ProductMiniumQuantityWholesale = P001T2_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = P001T2_n93ProductMiniumQuantityWholesale[0];
            A2BrandName = P001T2_A2BrandName[0];
            A5SupplierName = P001T2_A5SupplierName[0];
            A15ProductId = P001T2_A15ProductId[0];
            A19ProductDescription = P001T2_A19ProductDescription[0];
            n19ProductDescription = P001T2_n19ProductDescription[0];
            A28ProductCreatedDate = P001T2_A28ProductCreatedDate[0];
            A29ProductModifiedDate = P001T2_A29ProductModifiedDate[0];
            A87ProductWholesaleProfit = P001T2_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = P001T2_n87ProductWholesaleProfit[0];
            A85ProductCostPrice = P001T2_A85ProductCostPrice[0];
            n85ProductCostPrice = P001T2_n85ProductCostPrice[0];
            A89ProductRetailProfit = P001T2_A89ProductRetailProfit[0];
            n89ProductRetailProfit = P001T2_n89ProductRetailProfit[0];
            A2BrandName = P001T2_A2BrandName[0];
            A5SupplierName = P001T2_A5SupplierName[0];
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
            AV12CellRow = (int)(AV12CellRow+1);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = A55ProductCode;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = A16ProductName;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Number = A17ProductStock;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Number = A69ProductMiniumStock;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Number = (double)(A85ProductCostPrice);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Number = (double)(A89ProductRetailProfit);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Number = (double)(A90ProductRetailPrice);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Number = (double)(A87ProductWholesaleProfit);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Number = (double)(A88ProductWholesalePrice);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Number = A93ProductMiniumQuantityWholesale;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+10, 1, 1).Text = A2BrandName;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+11, 1, 1).Text = A5SupplierName;
            GXt_char4 = "";
            new productgetstate(context ).execute(  A15ProductId, out  GXt_char4) ;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+12, 1, 1).Text = GXt_char4;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+13, 1, 1).Text = A19ProductDescription;
            GXt_dtime5 = DateTimeUtil.ResetTime( A28ProductCreatedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+14, 1, 1).Date = GXt_dtime5;
            GXt_dtime5 = DateTimeUtil.ResetTime( A29ProductModifiedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+15, 1, 1).Date = GXt_dtime5;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV9ExcelDocument.Close();
         if ( AV16StorageProvider.GetPrivate(AV10Filename, AV15File, 1, AV17Messages) )
         {
            AV10Filename = AV15File.GetURI();
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV9ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV11ErrorMessage = AV9ExcelDocument.ErrDescription;
            AV9ExcelDocument.Close();
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV9ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P001T2_A1BrandId = new int[1] ;
         P001T2_n1BrandId = new bool[] {false} ;
         P001T2_A4SupplierId = new int[1] ;
         P001T2_A9SectorId = new int[1] ;
         P001T2_n9SectorId = new bool[] {false} ;
         P001T2_A55ProductCode = new string[] {""} ;
         P001T2_n55ProductCode = new bool[] {false} ;
         P001T2_A16ProductName = new string[] {""} ;
         P001T2_A17ProductStock = new int[1] ;
         P001T2_n17ProductStock = new bool[] {false} ;
         P001T2_A69ProductMiniumStock = new int[1] ;
         P001T2_n69ProductMiniumStock = new bool[] {false} ;
         P001T2_A93ProductMiniumQuantityWholesale = new short[1] ;
         P001T2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         P001T2_A2BrandName = new string[] {""} ;
         P001T2_A5SupplierName = new string[] {""} ;
         P001T2_A15ProductId = new int[1] ;
         P001T2_A19ProductDescription = new string[] {""} ;
         P001T2_n19ProductDescription = new bool[] {false} ;
         P001T2_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P001T2_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         P001T2_A87ProductWholesaleProfit = new decimal[1] ;
         P001T2_n87ProductWholesaleProfit = new bool[] {false} ;
         P001T2_A85ProductCostPrice = new decimal[1] ;
         P001T2_n85ProductCostPrice = new bool[] {false} ;
         P001T2_A89ProductRetailProfit = new decimal[1] ;
         P001T2_n89ProductRetailProfit = new bool[] {false} ;
         A55ProductCode = "";
         A16ProductName = "";
         A2BrandName = "";
         A5SupplierName = "";
         A19ProductDescription = "";
         A28ProductCreatedDate = DateTime.MinValue;
         A29ProductModifiedDate = DateTime.MinValue;
         GXt_char4 = "";
         GXt_dtime5 = (DateTime)(DateTime.MinValue);
         AV15File = new GxFile(context.GetPhysicalPath());
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16StorageProvider = new GxStorageProvider();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportsectorproductwc__default(),
            new Object[][] {
                new Object[] {
               P001T2_A1BrandId, P001T2_n1BrandId, P001T2_A4SupplierId, P001T2_A9SectorId, P001T2_n9SectorId, P001T2_A55ProductCode, P001T2_n55ProductCode, P001T2_A16ProductName, P001T2_A17ProductStock, P001T2_n17ProductStock,
               P001T2_A69ProductMiniumStock, P001T2_n69ProductMiniumStock, P001T2_A93ProductMiniumQuantityWholesale, P001T2_n93ProductMiniumQuantityWholesale, P001T2_A2BrandName, P001T2_A5SupplierName, P001T2_A15ProductId, P001T2_A19ProductDescription, P001T2_n19ProductDescription, P001T2_A28ProductCreatedDate,
               P001T2_A29ProductModifiedDate, P001T2_A87ProductWholesaleProfit, P001T2_n87ProductWholesaleProfit, P001T2_A85ProductCostPrice, P001T2_n85ProductCostPrice, P001T2_A89ProductRetailProfit, P001T2_n89ProductRetailProfit
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A93ProductMiniumQuantityWholesale ;
      private int AV18SectorId ;
      private int AV14Random ;
      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int A1BrandId ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A17ProductStock ;
      private int A69ProductMiniumStock ;
      private int A15ProductId ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private string GXt_char4 ;
      private DateTime GXt_dtime5 ;
      private DateTime A28ProductCreatedDate ;
      private DateTime A29ProductModifiedDate ;
      private bool returnInSub ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n55ProductCode ;
      private bool n17ProductStock ;
      private bool n69ProductMiniumStock ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n19ProductDescription ;
      private bool n87ProductWholesaleProfit ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A2BrandName ;
      private string A5SupplierName ;
      private string A19ProductDescription ;
      private GxStorageProvider AV16StorageProvider ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001T2_A1BrandId ;
      private bool[] P001T2_n1BrandId ;
      private int[] P001T2_A4SupplierId ;
      private int[] P001T2_A9SectorId ;
      private bool[] P001T2_n9SectorId ;
      private string[] P001T2_A55ProductCode ;
      private bool[] P001T2_n55ProductCode ;
      private string[] P001T2_A16ProductName ;
      private int[] P001T2_A17ProductStock ;
      private bool[] P001T2_n17ProductStock ;
      private int[] P001T2_A69ProductMiniumStock ;
      private bool[] P001T2_n69ProductMiniumStock ;
      private short[] P001T2_A93ProductMiniumQuantityWholesale ;
      private bool[] P001T2_n93ProductMiniumQuantityWholesale ;
      private string[] P001T2_A2BrandName ;
      private string[] P001T2_A5SupplierName ;
      private int[] P001T2_A15ProductId ;
      private string[] P001T2_A19ProductDescription ;
      private bool[] P001T2_n19ProductDescription ;
      private DateTime[] P001T2_A28ProductCreatedDate ;
      private DateTime[] P001T2_A29ProductModifiedDate ;
      private decimal[] P001T2_A87ProductWholesaleProfit ;
      private bool[] P001T2_n87ProductWholesaleProfit ;
      private decimal[] P001T2_A85ProductCostPrice ;
      private bool[] P001T2_n85ProductCostPrice ;
      private decimal[] P001T2_A89ProductRetailProfit ;
      private bool[] P001T2_n89ProductRetailProfit ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GxFile AV15File ;
   }

   public class exportsectorproductwc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001T2;
          prmP001T2 = new Object[] {
          new ParDef("@AV18SectorId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001T2", "SELECT T1.[BrandId], T1.[SupplierId], T1.[SectorId], T1.[ProductCode], T1.[ProductName], T1.[ProductStock], T1.[ProductMiniumStock], T1.[ProductMiniumQuantityWholesale], T2.[BrandName], T3.[SupplierName], T1.[ProductId], T1.[ProductDescription], T1.[ProductCreatedDate], T1.[ProductModifiedDate], T1.[ProductWholesaleProfit], T1.[ProductCostPrice], T1.[ProductRetailProfit] FROM (([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = T1.[SupplierId]) WHERE T1.[SectorId] = @AV18SectorId ORDER BY T1.[SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((short[]) buf[12])[0] = rslt.getShort(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((int[]) buf[16])[0] = rslt.getInt(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
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
