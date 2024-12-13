using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class productconversion : GXProcedure
   {
      public productconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", false);
      }

      public productconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         productconversion objproductconversion;
         objproductconversion = new productconversion();
         objproductconversion.context.SetSubmitInitialConfig(context);
         objproductconversion.initialize();
         Submit( executePrivateCatch,objproductconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productconversion)stateInfo).executePrivate();
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
         cmdBuffer=" SET IDENTITY_INSERT [GXA0005] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor PRODUCTCON2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A110ProductActive = PRODUCTCON2_A110ProductActive[0];
            n110ProductActive = PRODUCTCON2_n110ProductActive[0];
            A93ProductMiniumQuantityWholesale = PRODUCTCON2_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = PRODUCTCON2_n93ProductMiniumQuantityWholesale[0];
            A89ProductRetailProfit = PRODUCTCON2_A89ProductRetailProfit[0];
            n89ProductRetailProfit = PRODUCTCON2_n89ProductRetailProfit[0];
            A87ProductWholesaleProfit = PRODUCTCON2_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = PRODUCTCON2_n87ProductWholesaleProfit[0];
            A85ProductCostPrice = PRODUCTCON2_A85ProductCostPrice[0];
            A69ProductMiniumStock = PRODUCTCON2_A69ProductMiniumStock[0];
            A55ProductCode = PRODUCTCON2_A55ProductCode[0];
            n55ProductCode = PRODUCTCON2_n55ProductCode[0];
            A29ProductModifiedDate = PRODUCTCON2_A29ProductModifiedDate[0];
            n29ProductModifiedDate = PRODUCTCON2_n29ProductModifiedDate[0];
            A28ProductCreatedDate = PRODUCTCON2_A28ProductCreatedDate[0];
            A4SupplierId = PRODUCTCON2_A4SupplierId[0];
            A9SectorId = PRODUCTCON2_A9SectorId[0];
            n9SectorId = PRODUCTCON2_n9SectorId[0];
            A1BrandId = PRODUCTCON2_A1BrandId[0];
            A19ProductDescription = PRODUCTCON2_A19ProductDescription[0];
            n19ProductDescription = PRODUCTCON2_n19ProductDescription[0];
            A17ProductStock = PRODUCTCON2_A17ProductStock[0];
            A16ProductName = PRODUCTCON2_A16ProductName[0];
            A15ProductId = PRODUCTCON2_A15ProductId[0];
            /*
               INSERT RECORD ON TABLE GXA0005

            */
            AV2ProductId = A15ProductId;
            AV3ProductName = A16ProductName;
            AV4ProductStock = A17ProductStock;
            nV4ProductStock = false;
            if ( PRODUCTCON2_n19ProductDescription[0] )
            {
               AV5ProductDescription = "";
               nV5ProductDescription = false;
               nV5ProductDescription = true;
            }
            else
            {
               AV5ProductDescription = A19ProductDescription;
               nV5ProductDescription = false;
            }
            AV6BrandId = A1BrandId;
            nV6BrandId = false;
            if ( PRODUCTCON2_n9SectorId[0] )
            {
               AV7SectorId = 0;
               nV7SectorId = false;
               nV7SectorId = true;
            }
            else
            {
               AV7SectorId = A9SectorId;
               nV7SectorId = false;
            }
            AV8SupplierId = A4SupplierId;
            AV9ProductCreatedDate = A28ProductCreatedDate;
            if ( PRODUCTCON2_n29ProductModifiedDate[0] )
            {
               AV10ProductModifiedDate = context.localUtil.YMDToD( 1753, 1, 1);
            }
            else
            {
               AV10ProductModifiedDate = A29ProductModifiedDate;
            }
            if ( PRODUCTCON2_n55ProductCode[0] )
            {
               AV11ProductCode = "";
               nV11ProductCode = false;
               nV11ProductCode = true;
            }
            else
            {
               AV11ProductCode = A55ProductCode;
               nV11ProductCode = false;
            }
            AV12ProductMiniumStock = A69ProductMiniumStock;
            AV13ProductCostPrice = A85ProductCostPrice;
            if ( PRODUCTCON2_n87ProductWholesaleProfit[0] )
            {
               AV14ProductWholesaleProfit = 0;
               nV14ProductWholesaleProfit = false;
               nV14ProductWholesaleProfit = true;
            }
            else
            {
               AV14ProductWholesaleProfit = A87ProductWholesaleProfit;
               nV14ProductWholesaleProfit = false;
            }
            if ( PRODUCTCON2_n89ProductRetailProfit[0] )
            {
               AV15ProductRetailProfit = 0;
               nV15ProductRetailProfit = false;
               nV15ProductRetailProfit = true;
            }
            else
            {
               AV15ProductRetailProfit = A89ProductRetailProfit;
               nV15ProductRetailProfit = false;
            }
            if ( PRODUCTCON2_n93ProductMiniumQuantityWholesale[0] )
            {
               AV16ProductMiniumQuantityWholesale = 0;
               nV16ProductMiniumQuantityWholesale = false;
               nV16ProductMiniumQuantityWholesale = true;
            }
            else
            {
               AV16ProductMiniumQuantityWholesale = A93ProductMiniumQuantityWholesale;
               nV16ProductMiniumQuantityWholesale = false;
            }
            if ( PRODUCTCON2_n110ProductActive[0] )
            {
               AV17ProductActive = false;
               nV17ProductActive = false;
               nV17ProductActive = true;
            }
            else
            {
               AV17ProductActive = A110ProductActive;
               nV17ProductActive = false;
            }
            /* Using cursor PRODUCTCON3 */
            pr_default.execute(1, new Object[] {AV2ProductId, AV3ProductName, nV4ProductStock, AV4ProductStock, nV5ProductDescription, AV5ProductDescription, nV6BrandId, AV6BrandId, nV7SectorId, AV7SectorId, AV8SupplierId, AV9ProductCreatedDate, AV10ProductModifiedDate, nV11ProductCode, AV11ProductCode, AV12ProductMiniumStock, AV13ProductCostPrice, nV14ProductWholesaleProfit, AV14ProductWholesaleProfit, nV15ProductRetailProfit, AV15ProductRetailProfit, nV16ProductMiniumQuantityWholesale, AV16ProductMiniumQuantityWholesale, nV17ProductActive, AV17ProductActive});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0005");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" SET IDENTITY_INSERT [GXA0005] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
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
         cmdBuffer = "";
         scmdbuf = "";
         PRODUCTCON2_A110ProductActive = new bool[] {false} ;
         PRODUCTCON2_n110ProductActive = new bool[] {false} ;
         PRODUCTCON2_A93ProductMiniumQuantityWholesale = new short[1] ;
         PRODUCTCON2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         PRODUCTCON2_A89ProductRetailProfit = new decimal[1] ;
         PRODUCTCON2_n89ProductRetailProfit = new bool[] {false} ;
         PRODUCTCON2_A87ProductWholesaleProfit = new decimal[1] ;
         PRODUCTCON2_n87ProductWholesaleProfit = new bool[] {false} ;
         PRODUCTCON2_A85ProductCostPrice = new decimal[1] ;
         PRODUCTCON2_A69ProductMiniumStock = new int[1] ;
         PRODUCTCON2_A55ProductCode = new string[] {""} ;
         PRODUCTCON2_n55ProductCode = new bool[] {false} ;
         PRODUCTCON2_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         PRODUCTCON2_n29ProductModifiedDate = new bool[] {false} ;
         PRODUCTCON2_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         PRODUCTCON2_A4SupplierId = new int[1] ;
         PRODUCTCON2_A9SectorId = new int[1] ;
         PRODUCTCON2_n9SectorId = new bool[] {false} ;
         PRODUCTCON2_A1BrandId = new int[1] ;
         PRODUCTCON2_A19ProductDescription = new string[] {""} ;
         PRODUCTCON2_n19ProductDescription = new bool[] {false} ;
         PRODUCTCON2_A17ProductStock = new int[1] ;
         PRODUCTCON2_A16ProductName = new string[] {""} ;
         PRODUCTCON2_A15ProductId = new int[1] ;
         A55ProductCode = "";
         A29ProductModifiedDate = DateTime.MinValue;
         A28ProductCreatedDate = DateTime.MinValue;
         A19ProductDescription = "";
         A16ProductName = "";
         AV3ProductName = "";
         AV5ProductDescription = "";
         AV9ProductCreatedDate = DateTime.MinValue;
         AV10ProductModifiedDate = DateTime.MinValue;
         AV11ProductCode = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productconversion__default(),
            new Object[][] {
                new Object[] {
               PRODUCTCON2_A110ProductActive, PRODUCTCON2_n110ProductActive, PRODUCTCON2_A93ProductMiniumQuantityWholesale, PRODUCTCON2_n93ProductMiniumQuantityWholesale, PRODUCTCON2_A89ProductRetailProfit, PRODUCTCON2_n89ProductRetailProfit, PRODUCTCON2_A87ProductWholesaleProfit, PRODUCTCON2_n87ProductWholesaleProfit, PRODUCTCON2_A85ProductCostPrice, PRODUCTCON2_A69ProductMiniumStock,
               PRODUCTCON2_A55ProductCode, PRODUCTCON2_n55ProductCode, PRODUCTCON2_A29ProductModifiedDate, PRODUCTCON2_n29ProductModifiedDate, PRODUCTCON2_A28ProductCreatedDate, PRODUCTCON2_A4SupplierId, PRODUCTCON2_A9SectorId, PRODUCTCON2_n9SectorId, PRODUCTCON2_A1BrandId, PRODUCTCON2_A19ProductDescription,
               PRODUCTCON2_n19ProductDescription, PRODUCTCON2_A17ProductStock, PRODUCTCON2_A16ProductName, PRODUCTCON2_A15ProductId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A93ProductMiniumQuantityWholesale ;
      private short AV16ProductMiniumQuantityWholesale ;
      private int A69ProductMiniumStock ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A1BrandId ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private int GIGXA0005 ;
      private int AV2ProductId ;
      private int AV4ProductStock ;
      private int AV6BrandId ;
      private int AV7SectorId ;
      private int AV8SupplierId ;
      private int AV12ProductMiniumStock ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal AV13ProductCostPrice ;
      private decimal AV14ProductWholesaleProfit ;
      private decimal AV15ProductRetailProfit ;
      private string cmdBuffer ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A29ProductModifiedDate ;
      private DateTime A28ProductCreatedDate ;
      private DateTime AV9ProductCreatedDate ;
      private DateTime AV10ProductModifiedDate ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool n55ProductCode ;
      private bool n29ProductModifiedDate ;
      private bool n9SectorId ;
      private bool n19ProductDescription ;
      private bool nV4ProductStock ;
      private bool nV5ProductDescription ;
      private bool nV6BrandId ;
      private bool nV7SectorId ;
      private bool nV11ProductCode ;
      private bool nV14ProductWholesaleProfit ;
      private bool nV15ProductRetailProfit ;
      private bool nV16ProductMiniumQuantityWholesale ;
      private bool AV17ProductActive ;
      private bool nV17ProductActive ;
      private string A55ProductCode ;
      private string A19ProductDescription ;
      private string A16ProductName ;
      private string AV3ProductName ;
      private string AV5ProductDescription ;
      private string AV11ProductCode ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private bool[] PRODUCTCON2_A110ProductActive ;
      private bool[] PRODUCTCON2_n110ProductActive ;
      private short[] PRODUCTCON2_A93ProductMiniumQuantityWholesale ;
      private bool[] PRODUCTCON2_n93ProductMiniumQuantityWholesale ;
      private decimal[] PRODUCTCON2_A89ProductRetailProfit ;
      private bool[] PRODUCTCON2_n89ProductRetailProfit ;
      private decimal[] PRODUCTCON2_A87ProductWholesaleProfit ;
      private bool[] PRODUCTCON2_n87ProductWholesaleProfit ;
      private decimal[] PRODUCTCON2_A85ProductCostPrice ;
      private int[] PRODUCTCON2_A69ProductMiniumStock ;
      private string[] PRODUCTCON2_A55ProductCode ;
      private bool[] PRODUCTCON2_n55ProductCode ;
      private DateTime[] PRODUCTCON2_A29ProductModifiedDate ;
      private bool[] PRODUCTCON2_n29ProductModifiedDate ;
      private DateTime[] PRODUCTCON2_A28ProductCreatedDate ;
      private int[] PRODUCTCON2_A4SupplierId ;
      private int[] PRODUCTCON2_A9SectorId ;
      private bool[] PRODUCTCON2_n9SectorId ;
      private int[] PRODUCTCON2_A1BrandId ;
      private string[] PRODUCTCON2_A19ProductDescription ;
      private bool[] PRODUCTCON2_n19ProductDescription ;
      private int[] PRODUCTCON2_A17ProductStock ;
      private string[] PRODUCTCON2_A16ProductName ;
      private int[] PRODUCTCON2_A15ProductId ;
   }

   public class productconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmPRODUCTCON2;
          prmPRODUCTCON2 = new Object[] {
          };
          Object[] prmPRODUCTCON3;
          prmPRODUCTCON3 = new Object[] {
          new ParDef("@AV2ProductId",GXType.Int32,6,0) ,
          new ParDef("@AV3ProductName",GXType.VarChar,60,0) ,
          new ParDef("@AV4ProductStock",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@AV5ProductDescription",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("@AV6BrandId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@AV7SectorId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@AV8SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV9ProductCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV10ProductModifiedDate",GXType.Date,8,0) ,
          new ParDef("@AV11ProductCode",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV12ProductMiniumStock",GXType.Int32,6,0) ,
          new ParDef("@AV13ProductCostPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV14ProductWholesaleProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@AV15ProductRetailProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@AV16ProductMiniumQuantityWholesale",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@AV17ProductActive",GXType.Boolean,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("PRODUCTCON2", "SELECT [ProductActive], [ProductMiniumQuantityWholesale], [ProductRetailProfit], [ProductWholesaleProfit], [ProductCostPrice], [ProductMiniumStock], [ProductCode], [ProductModifiedDate], [ProductCreatedDate], [SupplierId], [SectorId], [BrandId], [ProductDescription], [ProductStock], [ProductName], [ProductId] FROM [Product] ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmPRODUCTCON2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("PRODUCTCON3", "INSERT INTO [GXA0005]([ProductId], [ProductName], [ProductStock], [ProductDescription], [BrandId], [SectorId], [SupplierId], [ProductCreatedDate], [ProductModifiedDate], [ProductCode], [ProductMiniumStock], [ProductCostPrice], [ProductWholesaleProfit], [ProductRetailProfit], [ProductMiniumQuantityWholesale], [ProductActive]) VALUES(@AV2ProductId, @AV3ProductName, @AV4ProductStock, @AV5ProductDescription, @AV6BrandId, @AV7SectorId, @AV8SupplierId, @AV9ProductCreatedDate, @AV10ProductModifiedDate, @AV11ProductCode, @AV12ProductMiniumStock, @AV13ProductCostPrice, @AV14ProductWholesaleProfit, @AV15ProductRetailProfit, @AV16ProductMiniumQuantityWholesale, @AV17ProductActive)", GxErrorMask.GX_NOMASK,prmPRODUCTCON3)
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(9);
                ((int[]) buf[15])[0] = rslt.getInt(10);
                ((int[]) buf[16])[0] = rslt.getInt(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((int[]) buf[18])[0] = rslt.getInt(12);
                ((string[]) buf[19])[0] = rslt.getVarchar(13);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                ((int[]) buf[21])[0] = rslt.getInt(14);
                ((string[]) buf[22])[0] = rslt.getVarchar(15);
                ((int[]) buf[23])[0] = rslt.getInt(16);
                return;
       }
    }

 }

}
