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
   public class registersalechargeproduct : GXProcedure
   {
      public registersalechargeproduct( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public registersalechargeproduct( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           out SdtSDTCarProducts_SDTCarProductsItem aP1_CarItem )
      {
         this.AV11ProductId = aP0_ProductId;
         this.AV8CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context) ;
         initialize();
         executePrivate();
         aP1_CarItem=this.AV8CarItem;
      }

      public SdtSDTCarProducts_SDTCarProductsItem executeUdp( int aP0_ProductId )
      {
         execute(aP0_ProductId, out aP1_CarItem);
         return AV8CarItem ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 out SdtSDTCarProducts_SDTCarProductsItem aP1_CarItem )
      {
         registersalechargeproduct objregistersalechargeproduct;
         objregistersalechargeproduct = new registersalechargeproduct();
         objregistersalechargeproduct.AV11ProductId = aP0_ProductId;
         objregistersalechargeproduct.AV8CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context) ;
         objregistersalechargeproduct.context.SetSubmitInitialConfig(context);
         objregistersalechargeproduct.initialize();
         Submit( executePrivateCatch,objregistersalechargeproduct);
         aP1_CarItem=this.AV8CarItem;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((registersalechargeproduct)stateInfo).executePrivate();
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
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         AV8CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         /* Using cursor P001E2 */
         pr_default.execute(0, new Object[] {AV11ProductId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15ProductId = P001E2_A15ProductId[0];
            A55ProductCode = P001E2_A55ProductCode[0];
            n55ProductCode = P001E2_n55ProductCode[0];
            A16ProductName = P001E2_A16ProductName[0];
            A93ProductMiniumQuantityWholesale = P001E2_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = P001E2_n93ProductMiniumQuantityWholesale[0];
            A17ProductStock = P001E2_A17ProductStock[0];
            n17ProductStock = P001E2_n17ProductStock[0];
            A87ProductWholesaleProfit = P001E2_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = P001E2_n87ProductWholesaleProfit[0];
            A85ProductCostPrice = P001E2_A85ProductCostPrice[0];
            n85ProductCostPrice = P001E2_n85ProductCostPrice[0];
            A89ProductRetailProfit = P001E2_A89ProductRetailProfit[0];
            n89ProductRetailProfit = P001E2_n89ProductRetailProfit[0];
            GXt_decimal2 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
            GXt_decimal3 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
            GXt_decimal4 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal4) ;
            A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal4);
            GXt_decimal4 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
            GXt_decimal3 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
            GXt_decimal2 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
            A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
            AV15ProductCode = A55ProductCode;
            /* Execute user subroutine: 'SEARCHPRODUCTWITHSAMECODE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV8CarItem.gxTpr_Id = A15ProductId;
            AV8CarItem.gxTpr_Name = A16ProductName;
            AV8CarItem.gxTpr_Unitprice = A90ProductRetailPrice;
            AV8CarItem.gxTpr_Retailprice = A90ProductRetailPrice;
            AV8CarItem.gxTpr_Wholesaleprice = A88ProductWholesalePrice;
            AV8CarItem.gxTpr_Productminiumquantitywholesale = A93ProductMiniumQuantityWholesale;
            if ( ! AV13ExistProductWithSameCode || String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) || P001E2_n55ProductCode[0] )
            {
               AV8CarItem.gxTpr_Stock = A17ProductStock;
            }
            else
            {
               AV8CarItem.gxTpr_Stock = AV14ProductStock;
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SEARCHPRODUCTWITHSAMECODE' Routine */
         returnInSub = false;
         AV14ProductStock = 0;
         AV13ExistProductWithSameCode = true;
         AV19GXLvl37 = 0;
         /* Using cursor P001E3 */
         pr_default.execute(1, new Object[] {AV15ProductCode});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A4SupplierId = P001E3_A4SupplierId[0];
            A112SupplierActive = P001E3_A112SupplierActive[0];
            A110ProductActive = P001E3_A110ProductActive[0];
            n110ProductActive = P001E3_n110ProductActive[0];
            A55ProductCode = P001E3_A55ProductCode[0];
            n55ProductCode = P001E3_n55ProductCode[0];
            A17ProductStock = P001E3_A17ProductStock[0];
            n17ProductStock = P001E3_n17ProductStock[0];
            A15ProductId = P001E3_A15ProductId[0];
            A112SupplierActive = P001E3_A112SupplierActive[0];
            AV19GXLvl37 = 1;
            AV14ProductStock = (int)(AV14ProductStock+A17ProductStock);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV19GXLvl37 == 0 )
         {
            AV13ExistProductWithSameCode = false;
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
         AV8CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         P001E2_A15ProductId = new int[1] ;
         P001E2_A55ProductCode = new string[] {""} ;
         P001E2_n55ProductCode = new bool[] {false} ;
         P001E2_A16ProductName = new string[] {""} ;
         P001E2_A93ProductMiniumQuantityWholesale = new short[1] ;
         P001E2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         P001E2_A17ProductStock = new int[1] ;
         P001E2_n17ProductStock = new bool[] {false} ;
         P001E2_A87ProductWholesaleProfit = new decimal[1] ;
         P001E2_n87ProductWholesaleProfit = new bool[] {false} ;
         P001E2_A85ProductCostPrice = new decimal[1] ;
         P001E2_n85ProductCostPrice = new bool[] {false} ;
         P001E2_A89ProductRetailProfit = new decimal[1] ;
         P001E2_n89ProductRetailProfit = new bool[] {false} ;
         A55ProductCode = "";
         A16ProductName = "";
         AV15ProductCode = "";
         P001E3_A4SupplierId = new int[1] ;
         P001E3_A112SupplierActive = new bool[] {false} ;
         P001E3_A110ProductActive = new bool[] {false} ;
         P001E3_n110ProductActive = new bool[] {false} ;
         P001E3_A55ProductCode = new string[] {""} ;
         P001E3_n55ProductCode = new bool[] {false} ;
         P001E3_A17ProductStock = new int[1] ;
         P001E3_n17ProductStock = new bool[] {false} ;
         P001E3_A15ProductId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.registersalechargeproduct__default(),
            new Object[][] {
                new Object[] {
               P001E2_A15ProductId, P001E2_A55ProductCode, P001E2_n55ProductCode, P001E2_A16ProductName, P001E2_A93ProductMiniumQuantityWholesale, P001E2_n93ProductMiniumQuantityWholesale, P001E2_A17ProductStock, P001E2_n17ProductStock, P001E2_A87ProductWholesaleProfit, P001E2_n87ProductWholesaleProfit,
               P001E2_A85ProductCostPrice, P001E2_n85ProductCostPrice, P001E2_A89ProductRetailProfit, P001E2_n89ProductRetailProfit
               }
               , new Object[] {
               P001E3_A4SupplierId, P001E3_A112SupplierActive, P001E3_A110ProductActive, P001E3_n110ProductActive, P001E3_A55ProductCode, P001E3_n55ProductCode, P001E3_A17ProductStock, P001E3_n17ProductStock, P001E3_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A93ProductMiniumQuantityWholesale ;
      private short AV19GXLvl37 ;
      private int AV11ProductId ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int AV14ProductStock ;
      private int A4SupplierId ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal4 ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private string scmdbuf ;
      private bool n55ProductCode ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n17ProductStock ;
      private bool n87ProductWholesaleProfit ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private bool returnInSub ;
      private bool AV13ExistProductWithSameCode ;
      private bool A112SupplierActive ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string AV15ProductCode ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001E2_A15ProductId ;
      private string[] P001E2_A55ProductCode ;
      private bool[] P001E2_n55ProductCode ;
      private string[] P001E2_A16ProductName ;
      private short[] P001E2_A93ProductMiniumQuantityWholesale ;
      private bool[] P001E2_n93ProductMiniumQuantityWholesale ;
      private int[] P001E2_A17ProductStock ;
      private bool[] P001E2_n17ProductStock ;
      private decimal[] P001E2_A87ProductWholesaleProfit ;
      private bool[] P001E2_n87ProductWholesaleProfit ;
      private decimal[] P001E2_A85ProductCostPrice ;
      private bool[] P001E2_n85ProductCostPrice ;
      private decimal[] P001E2_A89ProductRetailProfit ;
      private bool[] P001E2_n89ProductRetailProfit ;
      private int[] P001E3_A4SupplierId ;
      private bool[] P001E3_A112SupplierActive ;
      private bool[] P001E3_A110ProductActive ;
      private bool[] P001E3_n110ProductActive ;
      private string[] P001E3_A55ProductCode ;
      private bool[] P001E3_n55ProductCode ;
      private int[] P001E3_A17ProductStock ;
      private bool[] P001E3_n17ProductStock ;
      private int[] P001E3_A15ProductId ;
      private SdtSDTCarProducts_SDTCarProductsItem aP1_CarItem ;
      private SdtSDTCarProducts_SDTCarProductsItem AV8CarItem ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class registersalechargeproduct__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001E2;
          prmP001E2 = new Object[] {
          new ParDef("@AV11ProductId",GXType.Int32,6,0)
          };
          Object[] prmP001E3;
          prmP001E3 = new Object[] {
          new ParDef("@AV15ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001E2", "SELECT TOP 1 [ProductId], [ProductCode], [ProductName], [ProductMiniumQuantityWholesale], [ProductStock], [ProductWholesaleProfit], [ProductCostPrice], [ProductRetailProfit] FROM [Product] WHERE [ProductId] = @AV11ProductId ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001E2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001E3", "SELECT T1.[SupplierId], T2.[SupplierActive], T1.[ProductActive], T1.[ProductCode], T1.[ProductStock], T1.[ProductId] FROM ([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE (T1.[ProductActive] = 1) AND (T2.[SupplierActive] = 1) AND (Not (T1.[ProductCode] = '')) AND (Not T1.[ProductCode] IS NULL) AND (T1.[ProductCode] = @AV15ProductCode) ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001E3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
