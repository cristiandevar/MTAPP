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
   public class invoicegetlastid : GXProcedure
   {
      public invoicegetlastid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoicegetlastid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_InvoiceId )
      {
         this.AV8InvoiceId = 0 ;
         initialize();
         executePrivate();
         aP0_InvoiceId=this.AV8InvoiceId;
      }

      public int executeUdp( )
      {
         execute(out aP0_InvoiceId);
         return AV8InvoiceId ;
      }

      public void executeSubmit( out int aP0_InvoiceId )
      {
         invoicegetlastid objinvoicegetlastid;
         objinvoicegetlastid = new invoicegetlastid();
         objinvoicegetlastid.AV8InvoiceId = 0 ;
         objinvoicegetlastid.context.SetSubmitInitialConfig(context);
         objinvoicegetlastid.initialize();
         Submit( executePrivateCatch,objinvoicegetlastid);
         aP0_InvoiceId=this.AV8InvoiceId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((invoicegetlastid)stateInfo).executePrivate();
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
         AV11GXLvl1 = 0;
         /* Using cursor P002T2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20InvoiceId = P002T2_A20InvoiceId[0];
            AV11GXLvl1 = 1;
            AV8InvoiceId = A20InvoiceId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11GXLvl1 == 0 )
         {
            AV8InvoiceId = 0;
         }
         AV8InvoiceId = (int)(AV8InvoiceId+1);
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
         P002T2_A20InvoiceId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoicegetlastid__default(),
            new Object[][] {
                new Object[] {
               P002T2_A20InvoiceId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11GXLvl1 ;
      private int AV8InvoiceId ;
      private int A20InvoiceId ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002T2_A20InvoiceId ;
      private int aP0_InvoiceId ;
   }

   public class invoicegetlastid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002T2;
          prmP002T2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P002T2", "SELECT TOP 1 [InvoiceId] FROM [Invoice] ORDER BY [InvoiceId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002T2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}
