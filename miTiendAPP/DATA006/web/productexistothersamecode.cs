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
   public class productexistothersamecode : GXProcedure
   {
      public productexistothersamecode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productexistothersamecode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           string aP1_ProductCode ,
                           out bool aP2_Exist )
      {
         this.AV8ProductId = aP0_ProductId;
         this.AV9ProductCode = aP1_ProductCode;
         this.AV10Exist = false ;
         initialize();
         executePrivate();
         aP2_Exist=this.AV10Exist;
      }

      public bool executeUdp( int aP0_ProductId ,
                              string aP1_ProductCode )
      {
         execute(aP0_ProductId, aP1_ProductCode, out aP2_Exist);
         return AV10Exist ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 string aP1_ProductCode ,
                                 out bool aP2_Exist )
      {
         productexistothersamecode objproductexistothersamecode;
         objproductexistothersamecode = new productexistothersamecode();
         objproductexistothersamecode.AV8ProductId = aP0_ProductId;
         objproductexistothersamecode.AV9ProductCode = aP1_ProductCode;
         objproductexistothersamecode.AV10Exist = false ;
         objproductexistothersamecode.context.SetSubmitInitialConfig(context);
         objproductexistothersamecode.initialize();
         Submit( executePrivateCatch,objproductexistothersamecode);
         aP2_Exist=this.AV10Exist;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productexistothersamecode)stateInfo).executePrivate();
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
         AV13GXLvl1 = 0;
         /* Using cursor P002R2 */
         pr_default.execute(0, new Object[] {AV8ProductId, AV9ProductCode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P002R2_A4SupplierId[0];
            A112SupplierActive = P002R2_A112SupplierActive[0];
            A110ProductActive = P002R2_A110ProductActive[0];
            n110ProductActive = P002R2_n110ProductActive[0];
            A55ProductCode = P002R2_A55ProductCode[0];
            n55ProductCode = P002R2_n55ProductCode[0];
            A15ProductId = P002R2_A15ProductId[0];
            A112SupplierActive = P002R2_A112SupplierActive[0];
            AV13GXLvl1 = 1;
            AV10Exist = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl1 == 0 )
         {
            AV10Exist = false;
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
         scmdbuf = "";
         P002R2_A4SupplierId = new int[1] ;
         P002R2_A112SupplierActive = new bool[] {false} ;
         P002R2_A110ProductActive = new bool[] {false} ;
         P002R2_n110ProductActive = new bool[] {false} ;
         P002R2_A55ProductCode = new string[] {""} ;
         P002R2_n55ProductCode = new bool[] {false} ;
         P002R2_A15ProductId = new int[1] ;
         A55ProductCode = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productexistothersamecode__default(),
            new Object[][] {
                new Object[] {
               P002R2_A4SupplierId, P002R2_A112SupplierActive, P002R2_A110ProductActive, P002R2_n110ProductActive, P002R2_A55ProductCode, P002R2_n55ProductCode, P002R2_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13GXLvl1 ;
      private int AV8ProductId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private string scmdbuf ;
      private bool AV10Exist ;
      private bool A112SupplierActive ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n55ProductCode ;
      private string AV9ProductCode ;
      private string A55ProductCode ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002R2_A4SupplierId ;
      private bool[] P002R2_A112SupplierActive ;
      private bool[] P002R2_A110ProductActive ;
      private bool[] P002R2_n110ProductActive ;
      private string[] P002R2_A55ProductCode ;
      private bool[] P002R2_n55ProductCode ;
      private int[] P002R2_A15ProductId ;
      private bool aP2_Exist ;
   }

   public class productexistothersamecode__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002R2;
          prmP002R2 = new Object[] {
          new ParDef("@AV8ProductId",GXType.Int32,6,0) ,
          new ParDef("@AV9ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002R2", "SELECT T1.[SupplierId], T2.[SupplierActive], T1.[ProductActive], T1.[ProductCode], T1.[ProductId] FROM ([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE (T1.[ProductId] <> @AV8ProductId) AND (Not (T1.[ProductCode] = '')) AND (T1.[ProductActive] = 1) AND (T2.[SupplierActive] = 1) AND (T1.[ProductCode] = @AV9ProductCode) ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
