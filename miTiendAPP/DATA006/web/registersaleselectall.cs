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
   public class registersaleselectall : GXProcedure
   {
      public registersaleselectall( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public registersaleselectall( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Code ,
                           ref string aP1_Name ,
                           ref int aP2_Supplier ,
                           ref int aP3_Brand ,
                           ref int aP4_Sector ,
                           out GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> aP5_Car )
      {
         this.AV8Code = aP0_Code;
         this.AV9Name = aP1_Name;
         this.AV10Supplier = aP2_Supplier;
         this.AV11Brand = aP3_Brand;
         this.AV12Sector = aP4_Sector;
         this.AV13Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP1_Name=this.AV9Name;
         aP2_Supplier=this.AV10Supplier;
         aP3_Brand=this.AV11Brand;
         aP4_Sector=this.AV12Sector;
         aP5_Car=this.AV13Car;
      }

      public GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> executeUdp( string aP0_Code ,
                                                                                ref string aP1_Name ,
                                                                                ref int aP2_Supplier ,
                                                                                ref int aP3_Brand ,
                                                                                ref int aP4_Sector )
      {
         execute(aP0_Code, ref aP1_Name, ref aP2_Supplier, ref aP3_Brand, ref aP4_Sector, out aP5_Car);
         return AV13Car ;
      }

      public void executeSubmit( string aP0_Code ,
                                 ref string aP1_Name ,
                                 ref int aP2_Supplier ,
                                 ref int aP3_Brand ,
                                 ref int aP4_Sector ,
                                 out GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> aP5_Car )
      {
         registersaleselectall objregistersaleselectall;
         objregistersaleselectall = new registersaleselectall();
         objregistersaleselectall.AV8Code = aP0_Code;
         objregistersaleselectall.AV9Name = aP1_Name;
         objregistersaleselectall.AV10Supplier = aP2_Supplier;
         objregistersaleselectall.AV11Brand = aP3_Brand;
         objregistersaleselectall.AV12Sector = aP4_Sector;
         objregistersaleselectall.AV13Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB") ;
         objregistersaleselectall.context.SetSubmitInitialConfig(context);
         objregistersaleselectall.initialize();
         Submit( executePrivateCatch,objregistersaleselectall);
         aP1_Name=this.AV9Name;
         aP2_Supplier=this.AV10Supplier;
         aP3_Brand=this.AV11Brand;
         aP4_Sector=this.AV12Sector;
         aP5_Car=this.AV13Car;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((registersaleselectall)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV15Context, ref  AV16AllOk) ;
         if ( ! AV16AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV13Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8Code ,
                                              AV9Name ,
                                              AV10Supplier ,
                                              AV11Brand ,
                                              AV12Sector ,
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
         lV8Code = StringUtil.Concat( StringUtil.RTrim( AV8Code), "%", "");
         lV9Name = StringUtil.Concat( StringUtil.RTrim( AV9Name), "%", "");
         /* Using cursor P001F2 */
         pr_default.execute(0, new Object[] {lV8Code, lV9Name, AV10Supplier, AV11Brand, AV12Sector});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A112SupplierActive = P001F2_A112SupplierActive[0];
            A110ProductActive = P001F2_A110ProductActive[0];
            n110ProductActive = P001F2_n110ProductActive[0];
            A17ProductStock = P001F2_A17ProductStock[0];
            n17ProductStock = P001F2_n17ProductStock[0];
            A9SectorId = P001F2_A9SectorId[0];
            n9SectorId = P001F2_n9SectorId[0];
            A1BrandId = P001F2_A1BrandId[0];
            n1BrandId = P001F2_n1BrandId[0];
            A4SupplierId = P001F2_A4SupplierId[0];
            A16ProductName = P001F2_A16ProductName[0];
            A55ProductCode = P001F2_A55ProductCode[0];
            n55ProductCode = P001F2_n55ProductCode[0];
            A15ProductId = P001F2_A15ProductId[0];
            A112SupplierActive = P001F2_A112SupplierActive[0];
            AV14CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
            GXt_SdtSDTCarProducts_SDTCarProductsItem1 = AV14CarItem;
            new registersalechargeproduct(context ).execute(  A15ProductId, out  GXt_SdtSDTCarProducts_SDTCarProductsItem1) ;
            AV14CarItem = GXt_SdtSDTCarProducts_SDTCarProductsItem1;
            AV13Car.Add(AV14CarItem, 0);
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
         AV13Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV15Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         lV8Code = "";
         lV9Name = "";
         A55ProductCode = "";
         A16ProductName = "";
         P001F2_A112SupplierActive = new bool[] {false} ;
         P001F2_A110ProductActive = new bool[] {false} ;
         P001F2_n110ProductActive = new bool[] {false} ;
         P001F2_A17ProductStock = new int[1] ;
         P001F2_n17ProductStock = new bool[] {false} ;
         P001F2_A9SectorId = new int[1] ;
         P001F2_n9SectorId = new bool[] {false} ;
         P001F2_A1BrandId = new int[1] ;
         P001F2_n1BrandId = new bool[] {false} ;
         P001F2_A4SupplierId = new int[1] ;
         P001F2_A16ProductName = new string[] {""} ;
         P001F2_A55ProductCode = new string[] {""} ;
         P001F2_n55ProductCode = new bool[] {false} ;
         P001F2_A15ProductId = new int[1] ;
         AV14CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         GXt_SdtSDTCarProducts_SDTCarProductsItem1 = new SdtSDTCarProducts_SDTCarProductsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.registersaleselectall__default(),
            new Object[][] {
                new Object[] {
               P001F2_A112SupplierActive, P001F2_A110ProductActive, P001F2_n110ProductActive, P001F2_A17ProductStock, P001F2_n17ProductStock, P001F2_A9SectorId, P001F2_n9SectorId, P001F2_A1BrandId, P001F2_n1BrandId, P001F2_A4SupplierId,
               P001F2_A16ProductName, P001F2_A55ProductCode, P001F2_n55ProductCode, P001F2_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10Supplier ;
      private int AV11Brand ;
      private int AV12Sector ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private string scmdbuf ;
      private bool AV16AllOk ;
      private bool A110ProductActive ;
      private bool A112SupplierActive ;
      private bool n110ProductActive ;
      private bool n17ProductStock ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool n55ProductCode ;
      private string AV8Code ;
      private string AV9Name ;
      private string lV8Code ;
      private string lV9Name ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private IGxDataStore dsDefault ;
      private string aP1_Name ;
      private int aP2_Supplier ;
      private int aP3_Brand ;
      private int aP4_Sector ;
      private IDataStoreProvider pr_default ;
      private bool[] P001F2_A112SupplierActive ;
      private bool[] P001F2_A110ProductActive ;
      private bool[] P001F2_n110ProductActive ;
      private int[] P001F2_A17ProductStock ;
      private bool[] P001F2_n17ProductStock ;
      private int[] P001F2_A9SectorId ;
      private bool[] P001F2_n9SectorId ;
      private int[] P001F2_A1BrandId ;
      private bool[] P001F2_n1BrandId ;
      private int[] P001F2_A4SupplierId ;
      private string[] P001F2_A16ProductName ;
      private string[] P001F2_A55ProductCode ;
      private bool[] P001F2_n55ProductCode ;
      private int[] P001F2_A15ProductId ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> aP5_Car ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV13Car ;
      private SdtSDTCarProducts_SDTCarProductsItem AV14CarItem ;
      private SdtSDTCarProducts_SDTCarProductsItem GXt_SdtSDTCarProducts_SDTCarProductsItem1 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV15Context ;
   }

   public class registersaleselectall__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001F2( IGxContext context ,
                                             string AV8Code ,
                                             string AV9Name ,
                                             int AV10Supplier ,
                                             int AV11Brand ,
                                             int AV12Sector ,
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
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[SupplierActive], T1.[ProductActive], T1.[ProductStock], T1.[SectorId], T1.[BrandId], T1.[SupplierId], T1.[ProductName], T1.[ProductCode], T1.[ProductId] FROM ([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId])";
         AddWhere(sWhereString, "(T1.[ProductStock] > 0)");
         AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         AddWhere(sWhereString, "(T2.[SupplierActive] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV8Code)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV9Name)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV10Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV10Supplier)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV11Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV11Brand)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV12Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV12Sector)");
         }
         else
         {
            GXv_int2[4] = 1;
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
                     return conditional_P001F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (bool)dynConstraints[11] , (bool)dynConstraints[12] );
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
          Object[] prmP001F2;
          prmP001F2 = new Object[] {
          new ParDef("@lV8Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV9Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV10Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV11Brand",GXType.Int32,6,0) ,
          new ParDef("@AV12Sector",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001F2,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
