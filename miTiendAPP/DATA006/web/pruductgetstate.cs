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
   public class pruductgetstate : GXProcedure
   {
      public pruductgetstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public pruductgetstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           out string aP1_State )
      {
         this.AV8ProductId = aP0_ProductId;
         this.AV9State = "" ;
         initialize();
         executePrivate();
         aP1_State=this.AV9State;
      }

      public string executeUdp( int aP0_ProductId )
      {
         execute(aP0_ProductId, out aP1_State);
         return AV9State ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 out string aP1_State )
      {
         pruductgetstate objpruductgetstate;
         objpruductgetstate = new pruductgetstate();
         objpruductgetstate.AV8ProductId = aP0_ProductId;
         objpruductgetstate.AV9State = "" ;
         objpruductgetstate.context.SetSubmitInitialConfig(context);
         objpruductgetstate.initialize();
         Submit( executePrivateCatch,objpruductgetstate);
         aP1_State=this.AV9State;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pruductgetstate)stateInfo).executePrivate();
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
         /* Using cursor P002J2 */
         pr_default.execute(0, new Object[] {AV8ProductId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15ProductId = P002J2_A15ProductId[0];
            A110ProductActive = P002J2_A110ProductActive[0];
            n110ProductActive = P002J2_n110ProductActive[0];
            AV9State = (A110ProductActive ? "Enabled" : "Disabled");
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV9State = "";
         scmdbuf = "";
         P002J2_A15ProductId = new int[1] ;
         P002J2_A110ProductActive = new bool[] {false} ;
         P002J2_n110ProductActive = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pruductgetstate__default(),
            new Object[][] {
                new Object[] {
               P002J2_A15ProductId, P002J2_A110ProductActive, P002J2_n110ProductActive
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8ProductId ;
      private int A15ProductId ;
      private string scmdbuf ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private string AV9State ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002J2_A15ProductId ;
      private bool[] P002J2_A110ProductActive ;
      private bool[] P002J2_n110ProductActive ;
      private string aP1_State ;
   }

   public class pruductgetstate__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002J2;
          prmP002J2 = new Object[] {
          new ParDef("@AV8ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002J2", "SELECT TOP 1 [ProductId], [ProductActive] FROM [Product] WHERE [ProductId] = @AV8ProductId ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
