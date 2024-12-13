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
   public class invoicegetmonthperyear : GXProcedure
   {
      public invoicegetmonthperyear( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoicegetmonthperyear( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Year ,
                           out GxSimpleCollection<short> aP1_Months )
      {
         this.AV10Year = aP0_Year;
         this.AV11Months = new GxSimpleCollection<short>() ;
         initialize();
         executePrivate();
         aP1_Months=this.AV11Months;
      }

      public GxSimpleCollection<short> executeUdp( short aP0_Year )
      {
         execute(aP0_Year, out aP1_Months);
         return AV11Months ;
      }

      public void executeSubmit( short aP0_Year ,
                                 out GxSimpleCollection<short> aP1_Months )
      {
         invoicegetmonthperyear objinvoicegetmonthperyear;
         objinvoicegetmonthperyear = new invoicegetmonthperyear();
         objinvoicegetmonthperyear.AV10Year = aP0_Year;
         objinvoicegetmonthperyear.AV11Months = new GxSimpleCollection<short>() ;
         objinvoicegetmonthperyear.context.SetSubmitInitialConfig(context);
         objinvoicegetmonthperyear.initialize();
         Submit( executePrivateCatch,objinvoicegetmonthperyear);
         aP1_Months=this.AV11Months;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((invoicegetmonthperyear)stateInfo).executePrivate();
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
         AV11Months.Clear();
         AV15GXLvl2 = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10Year ,
                                              A38InvoiceCreatedDate ,
                                              A94InvoiceActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P002V2 */
         pr_default.execute(0, new Object[] {AV10Year});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A38InvoiceCreatedDate = P002V2_A38InvoiceCreatedDate[0];
            A94InvoiceActive = P002V2_A94InvoiceActive[0];
            A20InvoiceId = P002V2_A20InvoiceId[0];
            AV15GXLvl2 = 1;
            AV12Month = (short)(DateTimeUtil.Month( A38InvoiceCreatedDate));
            if ( AV11Months.IndexOf(AV12Month) == 0 )
            {
               AV11Months.Add(AV12Month, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV15GXLvl2 == 0 )
         {
            AV11Months.Clear();
         }
         AV11Months.Sort("");
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
         AV11Months = new GxSimpleCollection<short>();
         scmdbuf = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         P002V2_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P002V2_A94InvoiceActive = new bool[] {false} ;
         P002V2_A20InvoiceId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoicegetmonthperyear__default(),
            new Object[][] {
                new Object[] {
               P002V2_A38InvoiceCreatedDate, P002V2_A94InvoiceActive, P002V2_A20InvoiceId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10Year ;
      private short AV15GXLvl2 ;
      private short AV12Month ;
      private int A20InvoiceId ;
      private string scmdbuf ;
      private DateTime A38InvoiceCreatedDate ;
      private bool A94InvoiceActive ;
      private GxSimpleCollection<short> AV11Months ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P002V2_A38InvoiceCreatedDate ;
      private bool[] P002V2_A94InvoiceActive ;
      private int[] P002V2_A20InvoiceId ;
      private GxSimpleCollection<short> aP1_Months ;
   }

   public class invoicegetmonthperyear__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002V2( IGxContext context ,
                                             short AV10Year ,
                                             DateTime A38InvoiceCreatedDate ,
                                             bool A94InvoiceActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [InvoiceCreatedDate], [InvoiceActive], [InvoiceId] FROM [Invoice]";
         AddWhere(sWhereString, "([InvoiceActive] = 1)");
         if ( ! (0==AV10Year) )
         {
            AddWhere(sWhereString, "(YEAR([InvoiceCreatedDate]) = @AV10Year)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [InvoiceCreatedDate] DESC";
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
                     return conditional_P002V2(context, (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (bool)dynConstraints[2] );
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
          Object[] prmP002V2;
          prmP002V2 = new Object[] {
          new ParDef("@AV10Year",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002V2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
