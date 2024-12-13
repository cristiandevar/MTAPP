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
   public class updateselectall : GXProcedure
   {
      public updateselectall( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public updateselectall( IGxContext context )
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
                           out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP5_ProductsSelected )
      {
         this.AV8Code = aP0_Code;
         this.AV9Name = aP1_Name;
         this.AV10Supplier = aP2_Supplier;
         this.AV11Brand = aP3_Brand;
         this.AV12Sector = aP4_Sector;
         this.AV13ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP1_Name=this.AV9Name;
         aP2_Supplier=this.AV10Supplier;
         aP3_Brand=this.AV11Brand;
         aP4_Sector=this.AV12Sector;
         aP5_ProductsSelected=this.AV13ProductsSelected;
      }

      public GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> executeUdp( string aP0_Code ,
                                                                                          ref string aP1_Name ,
                                                                                          ref int aP2_Supplier ,
                                                                                          ref int aP3_Brand ,
                                                                                          ref int aP4_Sector )
      {
         execute(aP0_Code, ref aP1_Name, ref aP2_Supplier, ref aP3_Brand, ref aP4_Sector, out aP5_ProductsSelected);
         return AV13ProductsSelected ;
      }

      public void executeSubmit( string aP0_Code ,
                                 ref string aP1_Name ,
                                 ref int aP2_Supplier ,
                                 ref int aP3_Brand ,
                                 ref int aP4_Sector ,
                                 out GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP5_ProductsSelected )
      {
         updateselectall objupdateselectall;
         objupdateselectall = new updateselectall();
         objupdateselectall.AV8Code = aP0_Code;
         objupdateselectall.AV9Name = aP1_Name;
         objupdateselectall.AV10Supplier = aP2_Supplier;
         objupdateselectall.AV11Brand = aP3_Brand;
         objupdateselectall.AV12Sector = aP4_Sector;
         objupdateselectall.AV13ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB") ;
         objupdateselectall.context.SetSubmitInitialConfig(context);
         objupdateselectall.initialize();
         Submit( executePrivateCatch,objupdateselectall);
         aP1_Name=this.AV9Name;
         aP2_Supplier=this.AV10Supplier;
         aP3_Brand=this.AV11Brand;
         aP4_Sector=this.AV12Sector;
         aP5_ProductsSelected=this.AV13ProductsSelected;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((updateselectall)stateInfo).executePrivate();
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
                                              A9SectorId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00172 */
         pr_default.execute(0, new Object[] {AV8Code, AV9Name, AV10Supplier, AV11Brand, AV12Sector});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A9SectorId = P00172_A9SectorId[0];
            n9SectorId = P00172_n9SectorId[0];
            A1BrandId = P00172_A1BrandId[0];
            n1BrandId = P00172_n1BrandId[0];
            A4SupplierId = P00172_A4SupplierId[0];
            A16ProductName = P00172_A16ProductName[0];
            A55ProductCode = P00172_A55ProductCode[0];
            n55ProductCode = P00172_n55ProductCode[0];
            A15ProductId = P00172_A15ProductId[0];
            AV14OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1 = AV14OneProduct;
            new updateloadoneproduct(context ).execute(  A15ProductId, out  GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1) ;
            AV14OneProduct = GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1;
            AV13ProductsSelected.Add(AV14OneProduct, 0);
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
         AV13ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV15Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         A55ProductCode = "";
         A16ProductName = "";
         P00172_A9SectorId = new int[1] ;
         P00172_n9SectorId = new bool[] {false} ;
         P00172_A1BrandId = new int[1] ;
         P00172_n1BrandId = new bool[] {false} ;
         P00172_A4SupplierId = new int[1] ;
         P00172_A16ProductName = new string[] {""} ;
         P00172_A55ProductCode = new string[] {""} ;
         P00172_n55ProductCode = new bool[] {false} ;
         P00172_A15ProductId = new int[1] ;
         AV14OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1 = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.updateselectall__default(),
            new Object[][] {
                new Object[] {
               P00172_A9SectorId, P00172_n9SectorId, P00172_A1BrandId, P00172_n1BrandId, P00172_A4SupplierId, P00172_A16ProductName, P00172_A55ProductCode, P00172_n55ProductCode, P00172_A15ProductId
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
      private int A15ProductId ;
      private string scmdbuf ;
      private bool AV16AllOk ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool n55ProductCode ;
      private string AV8Code ;
      private string AV9Name ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private IGxDataStore dsDefault ;
      private string aP1_Name ;
      private int aP2_Supplier ;
      private int aP3_Brand ;
      private int aP4_Sector ;
      private IDataStoreProvider pr_default ;
      private int[] P00172_A9SectorId ;
      private bool[] P00172_n9SectorId ;
      private int[] P00172_A1BrandId ;
      private bool[] P00172_n1BrandId ;
      private int[] P00172_A4SupplierId ;
      private string[] P00172_A16ProductName ;
      private string[] P00172_A55ProductCode ;
      private bool[] P00172_n55ProductCode ;
      private int[] P00172_A15ProductId ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> aP5_ProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV13ProductsSelected ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV14OneProduct ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV15Context ;
   }

   public class updateselectall__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00172( IGxContext context ,
                                             string AV8Code ,
                                             string AV9Name ,
                                             int AV10Supplier ,
                                             int AV11Brand ,
                                             int AV12Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [SectorId], [BrandId], [SupplierId], [ProductName], [ProductCode], [ProductId] FROM [Product]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Code)) )
         {
            AddWhere(sWhereString, "([ProductCode] = @AV8Code)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Name)) )
         {
            AddWhere(sWhereString, "([ProductName] = @AV9Name)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV10Supplier) )
         {
            AddWhere(sWhereString, "([SupplierId] = @AV10Supplier)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV11Brand) )
         {
            AddWhere(sWhereString, "([BrandId] = @AV11Brand)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV12Sector) )
         {
            AddWhere(sWhereString, "([SectorId] = @AV12Sector)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProductId]";
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
                     return conditional_P00172(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
          Object[] prmP00172;
          prmP00172 = new Object[] {
          new ParDef("@AV8Code",GXType.NVarChar,100,0) ,
          new ParDef("@AV9Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV10Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV11Brand",GXType.Int32,6,0) ,
          new ParDef("@AV12Sector",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00172", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00172,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
