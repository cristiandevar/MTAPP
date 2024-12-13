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
   public class suppliercandisable : GXProcedure
   {
      public suppliercandisable( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public suppliercandisable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId ,
                           out bool aP1_CanDisabled ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_CanMessages )
      {
         this.AV8SupplierId = aP0_SupplierId;
         this.AV9CanDisabled = false ;
         this.AV10CanMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP1_CanDisabled=this.AV9CanDisabled;
         aP2_CanMessages=this.AV10CanMessages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_SupplierId ,
                                                                             out bool aP1_CanDisabled )
      {
         execute(aP0_SupplierId, out aP1_CanDisabled, out aP2_CanMessages);
         return AV10CanMessages ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 out bool aP1_CanDisabled ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_CanMessages )
      {
         suppliercandisable objsuppliercandisable;
         objsuppliercandisable = new suppliercandisable();
         objsuppliercandisable.AV8SupplierId = aP0_SupplierId;
         objsuppliercandisable.AV9CanDisabled = false ;
         objsuppliercandisable.AV10CanMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objsuppliercandisable.context.SetSubmitInitialConfig(context);
         objsuppliercandisable.initialize();
         Submit( executePrivateCatch,objsuppliercandisable);
         aP1_CanDisabled=this.AV9CanDisabled;
         aP2_CanMessages=this.AV10CanMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((suppliercandisable)stateInfo).executePrivate();
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
         AV9CanDisabled = true;
         /* Using cursor P002C2 */
         pr_default.execute(0, new Object[] {AV8SupplierId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P002C2_A4SupplierId[0];
            /* Using cursor P002C3 */
            pr_default.execute(1, new Object[] {A4SupplierId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A66PurchaseOrderClosedDate = P002C3_A66PurchaseOrderClosedDate[0];
               n66PurchaseOrderClosedDate = P002C3_n66PurchaseOrderClosedDate[0];
               A79PurchaseOrderActive = P002C3_A79PurchaseOrderActive[0];
               A50PurchaseOrderId = P002C3_A50PurchaseOrderId[0];
               AV9CanDisabled = false;
               AV11Message.gxTpr_Id = "PurchaseOrder";
               AV11Message.gxTpr_Description = "Purchase order nro "+StringUtil.Str( (decimal)(A50PurchaseOrderId), 6, 0)+" pending";
               AV10CanMessages.Add(AV11Message, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         AV10CanMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         scmdbuf = "";
         P002C2_A4SupplierId = new int[1] ;
         P002C3_A4SupplierId = new int[1] ;
         P002C3_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P002C3_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P002C3_A79PurchaseOrderActive = new bool[] {false} ;
         P002C3_A50PurchaseOrderId = new int[1] ;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.suppliercandisable__default(),
            new Object[][] {
                new Object[] {
               P002C2_A4SupplierId
               }
               , new Object[] {
               P002C3_A4SupplierId, P002C3_A66PurchaseOrderClosedDate, P002C3_n66PurchaseOrderClosedDate, P002C3_A79PurchaseOrderActive, P002C3_A50PurchaseOrderId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8SupplierId ;
      private int A4SupplierId ;
      private int A50PurchaseOrderId ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool AV9CanDisabled ;
      private bool n66PurchaseOrderClosedDate ;
      private bool A79PurchaseOrderActive ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002C2_A4SupplierId ;
      private int[] P002C3_A4SupplierId ;
      private DateTime[] P002C3_A66PurchaseOrderClosedDate ;
      private bool[] P002C3_n66PurchaseOrderClosedDate ;
      private bool[] P002C3_A79PurchaseOrderActive ;
      private int[] P002C3_A50PurchaseOrderId ;
      private bool aP1_CanDisabled ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_CanMessages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10CanMessages ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
   }

   public class suppliercandisable__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002C2;
          prmP002C2 = new Object[] {
          new ParDef("@AV8SupplierId",GXType.Int32,6,0)
          };
          Object[] prmP002C3;
          prmP002C3 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002C2", "SELECT TOP 1 [SupplierId] FROM [Supplier] WHERE [SupplierId] = @AV8SupplierId ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002C3", "SELECT TOP 1 [SupplierId], [PurchaseOrderClosedDate], [PurchaseOrderActive], [PurchaseOrderId] FROM [PurchaseOrder] WHERE ([SupplierId] = @SupplierId) AND (( [PurchaseOrderActive] = 1)) AND (( [PurchaseOrderClosedDate] IS NULL or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ) or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )))) ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002C3,1, GxCacheFrequency.OFF ,false,true )
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
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
