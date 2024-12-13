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
   public class invoicegetyears : GXProcedure
   {
      public invoicegetyears( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoicegetyears( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GxSimpleCollection<short> aP0_Years )
      {
         this.AV9Years = new GxSimpleCollection<short>() ;
         initialize();
         executePrivate();
         aP0_Years=this.AV9Years;
      }

      public GxSimpleCollection<short> executeUdp( )
      {
         execute(out aP0_Years);
         return AV9Years ;
      }

      public void executeSubmit( out GxSimpleCollection<short> aP0_Years )
      {
         invoicegetyears objinvoicegetyears;
         objinvoicegetyears = new invoicegetyears();
         objinvoicegetyears.AV9Years = new GxSimpleCollection<short>() ;
         objinvoicegetyears.context.SetSubmitInitialConfig(context);
         objinvoicegetyears.initialize();
         Submit( executePrivateCatch,objinvoicegetyears);
         aP0_Years=this.AV9Years;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((invoicegetyears)stateInfo).executePrivate();
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
         /* Using cursor P002U2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A94InvoiceActive = P002U2_A94InvoiceActive[0];
            A38InvoiceCreatedDate = P002U2_A38InvoiceCreatedDate[0];
            A20InvoiceId = P002U2_A20InvoiceId[0];
            AV13GXLvl1 = 1;
            AV10Year = (short)(DateTimeUtil.Year( A38InvoiceCreatedDate));
            if ( AV9Years.IndexOf(AV10Year) == 0 )
            {
               AV9Years.Add(AV10Year, 0);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl1 == 0 )
         {
            AV9Years.Clear();
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
         AV9Years = new GxSimpleCollection<short>();
         scmdbuf = "";
         P002U2_A94InvoiceActive = new bool[] {false} ;
         P002U2_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P002U2_A20InvoiceId = new int[1] ;
         A38InvoiceCreatedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoicegetyears__default(),
            new Object[][] {
                new Object[] {
               P002U2_A94InvoiceActive, P002U2_A38InvoiceCreatedDate, P002U2_A20InvoiceId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13GXLvl1 ;
      private short AV10Year ;
      private int A20InvoiceId ;
      private string scmdbuf ;
      private DateTime A38InvoiceCreatedDate ;
      private bool A94InvoiceActive ;
      private GxSimpleCollection<short> AV9Years ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P002U2_A94InvoiceActive ;
      private DateTime[] P002U2_A38InvoiceCreatedDate ;
      private int[] P002U2_A20InvoiceId ;
      private GxSimpleCollection<short> aP0_Years ;
   }

   public class invoicegetyears__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002U2;
          prmP002U2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P002U2", "SELECT [InvoiceActive], [InvoiceCreatedDate], [InvoiceId] FROM [Invoice] WHERE [InvoiceActive] = 1 ORDER BY [InvoiceCreatedDate] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002U2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
