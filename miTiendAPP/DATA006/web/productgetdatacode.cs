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
   public class productgetdatacode : GXProcedure
   {
      public productgetdatacode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productgetdatacode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProductCode ,
                           out string aP1_ProductName ,
                           ref decimal aP2_ProductCostPrice ,
                           ref decimal aP3_ProductRetailProfit ,
                           ref short aP4_ProductMiniumQuantityWholesale ,
                           ref decimal aP5_ProductWholesaleProfit ,
                           ref int aP6_BrandId ,
                           ref int aP7_SectorId ,
                           ref int aP8_ProductMiniumStock ,
                           ref string aP9_ProductDescription )
      {
         this.AV8ProductCode = aP0_ProductCode;
         this.AV9ProductName = "" ;
         this.AV10ProductCostPrice = aP2_ProductCostPrice;
         this.AV11ProductRetailProfit = aP3_ProductRetailProfit;
         this.AV16ProductMiniumQuantityWholesale = aP4_ProductMiniumQuantityWholesale;
         this.AV12ProductWholesaleProfit = aP5_ProductWholesaleProfit;
         this.AV13BrandId = aP6_BrandId;
         this.AV15SectorId = aP7_SectorId;
         this.AV17ProductMiniumStock = aP8_ProductMiniumStock;
         this.AV18ProductDescription = aP9_ProductDescription;
         initialize();
         executePrivate();
         aP1_ProductName=this.AV9ProductName;
         aP2_ProductCostPrice=this.AV10ProductCostPrice;
         aP3_ProductRetailProfit=this.AV11ProductRetailProfit;
         aP4_ProductMiniumQuantityWholesale=this.AV16ProductMiniumQuantityWholesale;
         aP5_ProductWholesaleProfit=this.AV12ProductWholesaleProfit;
         aP6_BrandId=this.AV13BrandId;
         aP7_SectorId=this.AV15SectorId;
         aP8_ProductMiniumStock=this.AV17ProductMiniumStock;
         aP9_ProductDescription=this.AV18ProductDescription;
      }

      public string executeUdp( string aP0_ProductCode ,
                                out string aP1_ProductName ,
                                ref decimal aP2_ProductCostPrice ,
                                ref decimal aP3_ProductRetailProfit ,
                                ref short aP4_ProductMiniumQuantityWholesale ,
                                ref decimal aP5_ProductWholesaleProfit ,
                                ref int aP6_BrandId ,
                                ref int aP7_SectorId ,
                                ref int aP8_ProductMiniumStock )
      {
         execute(aP0_ProductCode, out aP1_ProductName, ref aP2_ProductCostPrice, ref aP3_ProductRetailProfit, ref aP4_ProductMiniumQuantityWholesale, ref aP5_ProductWholesaleProfit, ref aP6_BrandId, ref aP7_SectorId, ref aP8_ProductMiniumStock, ref aP9_ProductDescription);
         return AV18ProductDescription ;
      }

      public void executeSubmit( string aP0_ProductCode ,
                                 out string aP1_ProductName ,
                                 ref decimal aP2_ProductCostPrice ,
                                 ref decimal aP3_ProductRetailProfit ,
                                 ref short aP4_ProductMiniumQuantityWholesale ,
                                 ref decimal aP5_ProductWholesaleProfit ,
                                 ref int aP6_BrandId ,
                                 ref int aP7_SectorId ,
                                 ref int aP8_ProductMiniumStock ,
                                 ref string aP9_ProductDescription )
      {
         productgetdatacode objproductgetdatacode;
         objproductgetdatacode = new productgetdatacode();
         objproductgetdatacode.AV8ProductCode = aP0_ProductCode;
         objproductgetdatacode.AV9ProductName = "" ;
         objproductgetdatacode.AV10ProductCostPrice = aP2_ProductCostPrice;
         objproductgetdatacode.AV11ProductRetailProfit = aP3_ProductRetailProfit;
         objproductgetdatacode.AV16ProductMiniumQuantityWholesale = aP4_ProductMiniumQuantityWholesale;
         objproductgetdatacode.AV12ProductWholesaleProfit = aP5_ProductWholesaleProfit;
         objproductgetdatacode.AV13BrandId = aP6_BrandId;
         objproductgetdatacode.AV15SectorId = aP7_SectorId;
         objproductgetdatacode.AV17ProductMiniumStock = aP8_ProductMiniumStock;
         objproductgetdatacode.AV18ProductDescription = aP9_ProductDescription;
         objproductgetdatacode.context.SetSubmitInitialConfig(context);
         objproductgetdatacode.initialize();
         Submit( executePrivateCatch,objproductgetdatacode);
         aP1_ProductName=this.AV9ProductName;
         aP2_ProductCostPrice=this.AV10ProductCostPrice;
         aP3_ProductRetailProfit=this.AV11ProductRetailProfit;
         aP4_ProductMiniumQuantityWholesale=this.AV16ProductMiniumQuantityWholesale;
         aP5_ProductWholesaleProfit=this.AV12ProductWholesaleProfit;
         aP6_BrandId=this.AV13BrandId;
         aP7_SectorId=this.AV15SectorId;
         aP8_ProductMiniumStock=this.AV17ProductMiniumStock;
         aP9_ProductDescription=this.AV18ProductDescription;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productgetdatacode)stateInfo).executePrivate();
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ProductCode)) )
         {
            AV21GXLvl3 = 0;
            /* Using cursor P002L2 */
            pr_default.execute(0, new Object[] {AV8ProductCode});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A55ProductCode = P002L2_A55ProductCode[0];
               n55ProductCode = P002L2_n55ProductCode[0];
               A85ProductCostPrice = P002L2_A85ProductCostPrice[0];
               n85ProductCostPrice = P002L2_n85ProductCostPrice[0];
               A16ProductName = P002L2_A16ProductName[0];
               A89ProductRetailProfit = P002L2_A89ProductRetailProfit[0];
               n89ProductRetailProfit = P002L2_n89ProductRetailProfit[0];
               A93ProductMiniumQuantityWholesale = P002L2_A93ProductMiniumQuantityWholesale[0];
               n93ProductMiniumQuantityWholesale = P002L2_n93ProductMiniumQuantityWholesale[0];
               A87ProductWholesaleProfit = P002L2_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = P002L2_n87ProductWholesaleProfit[0];
               A1BrandId = P002L2_A1BrandId[0];
               n1BrandId = P002L2_n1BrandId[0];
               A9SectorId = P002L2_A9SectorId[0];
               n9SectorId = P002L2_n9SectorId[0];
               A69ProductMiniumStock = P002L2_A69ProductMiniumStock[0];
               n69ProductMiniumStock = P002L2_n69ProductMiniumStock[0];
               A19ProductDescription = P002L2_A19ProductDescription[0];
               n19ProductDescription = P002L2_n19ProductDescription[0];
               A15ProductId = P002L2_A15ProductId[0];
               AV21GXLvl3 = 1;
               AV10ProductCostPrice = A85ProductCostPrice;
               AV9ProductName = A16ProductName;
               AV11ProductRetailProfit = A89ProductRetailProfit;
               AV16ProductMiniumQuantityWholesale = A93ProductMiniumQuantityWholesale;
               AV12ProductWholesaleProfit = A87ProductWholesaleProfit;
               AV13BrandId = A1BrandId;
               AV15SectorId = A9SectorId;
               AV17ProductMiniumStock = A69ProductMiniumStock;
               AV18ProductDescription = A19ProductDescription;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV21GXLvl3 == 0 )
            {
               AV10ProductCostPrice = 0;
               AV9ProductName = "";
               AV11ProductRetailProfit = 0;
               AV16ProductMiniumQuantityWholesale = 0;
               AV12ProductWholesaleProfit = 0;
               AV13BrandId = 0;
               AV15SectorId = 0;
               AV17ProductMiniumStock = 0;
               AV18ProductDescription = "";
            }
         }
         else
         {
            AV10ProductCostPrice = 0;
            AV9ProductName = "";
            AV11ProductRetailProfit = 0;
            AV16ProductMiniumQuantityWholesale = 0;
            AV12ProductWholesaleProfit = 0;
            AV13BrandId = 0;
            AV15SectorId = 0;
            AV17ProductMiniumStock = 0;
            AV18ProductDescription = "";
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
         AV9ProductName = "";
         scmdbuf = "";
         P002L2_A55ProductCode = new string[] {""} ;
         P002L2_n55ProductCode = new bool[] {false} ;
         P002L2_A85ProductCostPrice = new decimal[1] ;
         P002L2_n85ProductCostPrice = new bool[] {false} ;
         P002L2_A16ProductName = new string[] {""} ;
         P002L2_A89ProductRetailProfit = new decimal[1] ;
         P002L2_n89ProductRetailProfit = new bool[] {false} ;
         P002L2_A93ProductMiniumQuantityWholesale = new short[1] ;
         P002L2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         P002L2_A87ProductWholesaleProfit = new decimal[1] ;
         P002L2_n87ProductWholesaleProfit = new bool[] {false} ;
         P002L2_A1BrandId = new int[1] ;
         P002L2_n1BrandId = new bool[] {false} ;
         P002L2_A9SectorId = new int[1] ;
         P002L2_n9SectorId = new bool[] {false} ;
         P002L2_A69ProductMiniumStock = new int[1] ;
         P002L2_n69ProductMiniumStock = new bool[] {false} ;
         P002L2_A19ProductDescription = new string[] {""} ;
         P002L2_n19ProductDescription = new bool[] {false} ;
         P002L2_A15ProductId = new int[1] ;
         A55ProductCode = "";
         A16ProductName = "";
         A19ProductDescription = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productgetdatacode__default(),
            new Object[][] {
                new Object[] {
               P002L2_A55ProductCode, P002L2_n55ProductCode, P002L2_A85ProductCostPrice, P002L2_n85ProductCostPrice, P002L2_A16ProductName, P002L2_A89ProductRetailProfit, P002L2_n89ProductRetailProfit, P002L2_A93ProductMiniumQuantityWholesale, P002L2_n93ProductMiniumQuantityWholesale, P002L2_A87ProductWholesaleProfit,
               P002L2_n87ProductWholesaleProfit, P002L2_A1BrandId, P002L2_n1BrandId, P002L2_A9SectorId, P002L2_n9SectorId, P002L2_A69ProductMiniumStock, P002L2_n69ProductMiniumStock, P002L2_A19ProductDescription, P002L2_n19ProductDescription, P002L2_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16ProductMiniumQuantityWholesale ;
      private short AV21GXLvl3 ;
      private short A93ProductMiniumQuantityWholesale ;
      private int AV13BrandId ;
      private int AV15SectorId ;
      private int AV17ProductMiniumStock ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A69ProductMiniumStock ;
      private int A15ProductId ;
      private decimal AV10ProductCostPrice ;
      private decimal AV11ProductRetailProfit ;
      private decimal AV12ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private string scmdbuf ;
      private bool n55ProductCode ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n87ProductWholesaleProfit ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n69ProductMiniumStock ;
      private bool n19ProductDescription ;
      private string AV8ProductCode ;
      private string AV9ProductName ;
      private string AV18ProductDescription ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A19ProductDescription ;
      private IGxDataStore dsDefault ;
      private decimal aP2_ProductCostPrice ;
      private decimal aP3_ProductRetailProfit ;
      private short aP4_ProductMiniumQuantityWholesale ;
      private decimal aP5_ProductWholesaleProfit ;
      private int aP6_BrandId ;
      private int aP7_SectorId ;
      private int aP8_ProductMiniumStock ;
      private string aP9_ProductDescription ;
      private IDataStoreProvider pr_default ;
      private string[] P002L2_A55ProductCode ;
      private bool[] P002L2_n55ProductCode ;
      private decimal[] P002L2_A85ProductCostPrice ;
      private bool[] P002L2_n85ProductCostPrice ;
      private string[] P002L2_A16ProductName ;
      private decimal[] P002L2_A89ProductRetailProfit ;
      private bool[] P002L2_n89ProductRetailProfit ;
      private short[] P002L2_A93ProductMiniumQuantityWholesale ;
      private bool[] P002L2_n93ProductMiniumQuantityWholesale ;
      private decimal[] P002L2_A87ProductWholesaleProfit ;
      private bool[] P002L2_n87ProductWholesaleProfit ;
      private int[] P002L2_A1BrandId ;
      private bool[] P002L2_n1BrandId ;
      private int[] P002L2_A9SectorId ;
      private bool[] P002L2_n9SectorId ;
      private int[] P002L2_A69ProductMiniumStock ;
      private bool[] P002L2_n69ProductMiniumStock ;
      private string[] P002L2_A19ProductDescription ;
      private bool[] P002L2_n19ProductDescription ;
      private int[] P002L2_A15ProductId ;
      private string aP1_ProductName ;
   }

   public class productgetdatacode__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002L2;
          prmP002L2 = new Object[] {
          new ParDef("@AV8ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002L2", "SELECT TOP 1 [ProductCode], [ProductCostPrice], [ProductName], [ProductRetailProfit], [ProductMiniumQuantityWholesale], [ProductWholesaleProfit], [BrandId], [SectorId], [ProductMiniumStock], [ProductDescription], [ProductId] FROM [Product] WHERE [ProductCode] = @AV8ProductCode ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002L2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                return;
       }
    }

 }

}
