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
   public class productexistwithcode : GXProcedure
   {
      public productexistwithcode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productexistwithcode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProductCode ,
                           out int aP1_ProductId ,
                           out bool aP2_Exist )
      {
         this.AV8ProductCode = aP0_ProductCode;
         this.AV10ProductId = 0 ;
         this.AV9Exist = false ;
         initialize();
         executePrivate();
         aP1_ProductId=this.AV10ProductId;
         aP2_Exist=this.AV9Exist;
      }

      public bool executeUdp( string aP0_ProductCode ,
                              out int aP1_ProductId )
      {
         execute(aP0_ProductCode, out aP1_ProductId, out aP2_Exist);
         return AV9Exist ;
      }

      public void executeSubmit( string aP0_ProductCode ,
                                 out int aP1_ProductId ,
                                 out bool aP2_Exist )
      {
         productexistwithcode objproductexistwithcode;
         objproductexistwithcode = new productexistwithcode();
         objproductexistwithcode.AV8ProductCode = aP0_ProductCode;
         objproductexistwithcode.AV10ProductId = 0 ;
         objproductexistwithcode.AV9Exist = false ;
         objproductexistwithcode.context.SetSubmitInitialConfig(context);
         objproductexistwithcode.initialize();
         Submit( executePrivateCatch,objproductexistwithcode);
         aP1_ProductId=this.AV10ProductId;
         aP2_Exist=this.AV9Exist;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productexistwithcode)stateInfo).executePrivate();
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
         AV9Exist = false;
         /* Using cursor P002K2 */
         pr_default.execute(0, new Object[] {AV8ProductCode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A55ProductCode = P002K2_A55ProductCode[0];
            n55ProductCode = P002K2_n55ProductCode[0];
            A15ProductId = P002K2_A15ProductId[0];
            A87ProductWholesaleProfit = P002K2_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = P002K2_n87ProductWholesaleProfit[0];
            A89ProductRetailProfit = P002K2_A89ProductRetailProfit[0];
            n89ProductRetailProfit = P002K2_n89ProductRetailProfit[0];
            A85ProductCostPrice = P002K2_A85ProductCostPrice[0];
            n85ProductCostPrice = P002K2_n85ProductCostPrice[0];
            AV9Exist = true;
            AV10ProductId = A15ProductId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P002K2_A55ProductCode = new string[] {""} ;
         P002K2_n55ProductCode = new bool[] {false} ;
         P002K2_A15ProductId = new int[1] ;
         P002K2_A87ProductWholesaleProfit = new decimal[1] ;
         P002K2_n87ProductWholesaleProfit = new bool[] {false} ;
         P002K2_A89ProductRetailProfit = new decimal[1] ;
         P002K2_n89ProductRetailProfit = new bool[] {false} ;
         P002K2_A85ProductCostPrice = new decimal[1] ;
         P002K2_n85ProductCostPrice = new bool[] {false} ;
         A55ProductCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productexistwithcode__default(),
            new Object[][] {
                new Object[] {
               P002K2_A55ProductCode, P002K2_n55ProductCode, P002K2_A15ProductId, P002K2_A87ProductWholesaleProfit, P002K2_n87ProductWholesaleProfit, P002K2_A89ProductRetailProfit, P002K2_n89ProductRetailProfit, P002K2_A85ProductCostPrice, P002K2_n85ProductCostPrice
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10ProductId ;
      private int A15ProductId ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A89ProductRetailProfit ;
      private decimal A85ProductCostPrice ;
      private string scmdbuf ;
      private bool AV9Exist ;
      private bool n55ProductCode ;
      private bool n87ProductWholesaleProfit ;
      private bool n89ProductRetailProfit ;
      private bool n85ProductCostPrice ;
      private string AV8ProductCode ;
      private string A55ProductCode ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002K2_A55ProductCode ;
      private bool[] P002K2_n55ProductCode ;
      private int[] P002K2_A15ProductId ;
      private decimal[] P002K2_A87ProductWholesaleProfit ;
      private bool[] P002K2_n87ProductWholesaleProfit ;
      private decimal[] P002K2_A89ProductRetailProfit ;
      private bool[] P002K2_n89ProductRetailProfit ;
      private decimal[] P002K2_A85ProductCostPrice ;
      private bool[] P002K2_n85ProductCostPrice ;
      private int aP1_ProductId ;
      private bool aP2_Exist ;
   }

   public class productexistwithcode__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002K2;
          prmP002K2 = new Object[] {
          new ParDef("@AV8ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002K2", "SELECT TOP 1 [ProductCode], [ProductId], [ProductWholesaleProfit], [ProductRetailProfit], [ProductCostPrice] FROM [Product] WHERE [ProductCode] = @AV8ProductCode ORDER BY [ProductCostPrice] DESC, [ProductRetailProfit] DESC, [ProductWholesaleProfit] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002K2,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
