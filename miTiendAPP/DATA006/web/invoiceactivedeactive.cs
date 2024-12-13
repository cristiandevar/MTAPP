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
   public class invoiceactivedeactive : GXProcedure
   {
      public invoiceactivedeactive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoiceactivedeactive( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_InvoiceId ,
                           bool aP1_InvoiceActive ,
                           out bool aP2_AllOk ,
                           out string aP3_ErrorMessage )
      {
         this.AV8InvoiceId = aP0_InvoiceId;
         this.AV9InvoiceActive = aP1_InvoiceActive;
         this.AV12AllOk = false ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP2_AllOk=this.AV12AllOk;
         aP3_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( int aP0_InvoiceId ,
                                bool aP1_InvoiceActive ,
                                out bool aP2_AllOk )
      {
         execute(aP0_InvoiceId, aP1_InvoiceActive, out aP2_AllOk, out aP3_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( int aP0_InvoiceId ,
                                 bool aP1_InvoiceActive ,
                                 out bool aP2_AllOk ,
                                 out string aP3_ErrorMessage )
      {
         invoiceactivedeactive objinvoiceactivedeactive;
         objinvoiceactivedeactive = new invoiceactivedeactive();
         objinvoiceactivedeactive.AV8InvoiceId = aP0_InvoiceId;
         objinvoiceactivedeactive.AV9InvoiceActive = aP1_InvoiceActive;
         objinvoiceactivedeactive.AV12AllOk = false ;
         objinvoiceactivedeactive.AV11ErrorMessage = "" ;
         objinvoiceactivedeactive.context.SetSubmitInitialConfig(context);
         objinvoiceactivedeactive.initialize();
         Submit( executePrivateCatch,objinvoiceactivedeactive);
         aP2_AllOk=this.AV12AllOk;
         aP3_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((invoiceactivedeactive)stateInfo).executePrivate();
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
         AV17GXLvl1 = 0;
         /* Using cursor P002S2 */
         pr_default.execute(0, new Object[] {AV8InvoiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20InvoiceId = P002S2_A20InvoiceId[0];
            A38InvoiceCreatedDate = P002S2_A38InvoiceCreatedDate[0];
            A94InvoiceActive = P002S2_A94InvoiceActive[0];
            AV17GXLvl1 = 1;
            AV14DayDifference = (long)(DateTimeUtil.DDiff(DateTimeUtil.ServerDate( context, pr_default),A38InvoiceCreatedDate));
            if ( AV14DayDifference <= 7 )
            {
               A94InvoiceActive = (bool)(!AV9InvoiceActive);
               AV12AllOk = true;
            }
            else
            {
               AV12AllOk = false;
               AV11ErrorMessage = "The sale was made more than a week ago";
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P002S3 */
            pr_default.execute(1, new Object[] {A94InvoiceActive, A20InvoiceId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Invoice");
            if (true) break;
            /* Using cursor P002S4 */
            pr_default.execute(2, new Object[] {A94InvoiceActive, A20InvoiceId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("Invoice");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV17GXLvl1 == 0 )
         {
            AV12AllOk = false;
            AV11ErrorMessage = "Sale not Found";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("invoiceactivedeactive",pr_default);
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
         AV11ErrorMessage = "";
         scmdbuf = "";
         P002S2_A20InvoiceId = new int[1] ;
         P002S2_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P002S2_A94InvoiceActive = new bool[] {false} ;
         A38InvoiceCreatedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoiceactivedeactive__default(),
            new Object[][] {
                new Object[] {
               P002S2_A20InvoiceId, P002S2_A38InvoiceCreatedDate, P002S2_A94InvoiceActive
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV17GXLvl1 ;
      private int AV8InvoiceId ;
      private int A20InvoiceId ;
      private long AV14DayDifference ;
      private string scmdbuf ;
      private DateTime A38InvoiceCreatedDate ;
      private bool AV9InvoiceActive ;
      private bool AV12AllOk ;
      private bool A94InvoiceActive ;
      private string AV11ErrorMessage ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002S2_A20InvoiceId ;
      private DateTime[] P002S2_A38InvoiceCreatedDate ;
      private bool[] P002S2_A94InvoiceActive ;
      private bool aP2_AllOk ;
      private string aP3_ErrorMessage ;
   }

   public class invoiceactivedeactive__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002S2;
          prmP002S2 = new Object[] {
          new ParDef("@AV8InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP002S3;
          prmP002S3 = new Object[] {
          new ParDef("@InvoiceActive",GXType.Boolean,4,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP002S4;
          prmP002S4 = new Object[] {
          new ParDef("@InvoiceActive",GXType.Boolean,4,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002S2", "SELECT TOP 1 [InvoiceId], [InvoiceCreatedDate], [InvoiceActive] FROM [Invoice] WITH (UPDLOCK) WHERE [InvoiceId] = @AV8InvoiceId ORDER BY [InvoiceId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002S2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002S3", "UPDATE [Invoice] SET [InvoiceActive]=@InvoiceActive  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002S3)
             ,new CursorDef("P002S4", "UPDATE [Invoice] SET [InvoiceActive]=@InvoiceActive  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002S4)
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
