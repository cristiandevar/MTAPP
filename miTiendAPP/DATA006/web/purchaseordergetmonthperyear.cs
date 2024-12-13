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
   public class purchaseordergetmonthperyear : GXProcedure
   {
      public purchaseordergetmonthperyear( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordergetmonthperyear( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Year ,
                           out GxSimpleCollection<short> aP1_Months )
      {
         this.AV8Year = aP0_Year;
         this.AV9Months = new GxSimpleCollection<short>() ;
         initialize();
         executePrivate();
         aP1_Months=this.AV9Months;
      }

      public GxSimpleCollection<short> executeUdp( short aP0_Year )
      {
         execute(aP0_Year, out aP1_Months);
         return AV9Months ;
      }

      public void executeSubmit( short aP0_Year ,
                                 out GxSimpleCollection<short> aP1_Months )
      {
         purchaseordergetmonthperyear objpurchaseordergetmonthperyear;
         objpurchaseordergetmonthperyear = new purchaseordergetmonthperyear();
         objpurchaseordergetmonthperyear.AV8Year = aP0_Year;
         objpurchaseordergetmonthperyear.AV9Months = new GxSimpleCollection<short>() ;
         objpurchaseordergetmonthperyear.context.SetSubmitInitialConfig(context);
         objpurchaseordergetmonthperyear.initialize();
         Submit( executePrivateCatch,objpurchaseordergetmonthperyear);
         aP1_Months=this.AV9Months;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordergetmonthperyear)stateInfo).executePrivate();
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
         AV9Months.Clear();
         AV13GXLvl2 = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8Year ,
                                              A66PurchaseOrderClosedDate ,
                                              A79PurchaseOrderActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P002X2 */
         pr_default.execute(0, new Object[] {AV8Year});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A66PurchaseOrderClosedDate = P002X2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P002X2_n66PurchaseOrderClosedDate[0];
            A79PurchaseOrderActive = P002X2_A79PurchaseOrderActive[0];
            A50PurchaseOrderId = P002X2_A50PurchaseOrderId[0];
            AV13GXLvl2 = 1;
            AV10Month = (short)(DateTimeUtil.Month( A66PurchaseOrderClosedDate));
            if ( AV9Months.IndexOf(AV10Month) == 0 )
            {
               AV9Months.Add(AV10Month, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl2 == 0 )
         {
            AV9Months.Clear();
         }
         AV9Months.Sort("");
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
         AV9Months = new GxSimpleCollection<short>();
         scmdbuf = "";
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         P002X2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P002X2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P002X2_A79PurchaseOrderActive = new bool[] {false} ;
         P002X2_A50PurchaseOrderId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordergetmonthperyear__default(),
            new Object[][] {
                new Object[] {
               P002X2_A66PurchaseOrderClosedDate, P002X2_n66PurchaseOrderClosedDate, P002X2_A79PurchaseOrderActive, P002X2_A50PurchaseOrderId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Year ;
      private short AV13GXLvl2 ;
      private short AV10Month ;
      private int A50PurchaseOrderId ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool A79PurchaseOrderActive ;
      private bool n66PurchaseOrderClosedDate ;
      private GxSimpleCollection<short> AV9Months ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P002X2_A66PurchaseOrderClosedDate ;
      private bool[] P002X2_n66PurchaseOrderClosedDate ;
      private bool[] P002X2_A79PurchaseOrderActive ;
      private int[] P002X2_A50PurchaseOrderId ;
      private GxSimpleCollection<short> aP1_Months ;
   }

   public class purchaseordergetmonthperyear__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002X2( IGxContext context ,
                                             short AV8Year ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             bool A79PurchaseOrderActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PurchaseOrderClosedDate], [PurchaseOrderActive], [PurchaseOrderId] FROM [PurchaseOrder]";
         AddWhere(sWhereString, "([PurchaseOrderActive] = 1)");
         AddWhere(sWhereString, "(Not ( [PurchaseOrderClosedDate] IS NULL or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ) or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         if ( ! (0==AV8Year) )
         {
            AddWhere(sWhereString, "(YEAR([PurchaseOrderClosedDate]) = @AV8Year)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PurchaseOrderClosedDate] DESC";
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
                     return conditional_P002X2(context, (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (bool)dynConstraints[2] );
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
          Object[] prmP002X2;
          prmP002X2 = new Object[] {
          new ParDef("@AV8Year",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002X2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
