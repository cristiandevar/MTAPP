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
   public class purchaseordermodifybysupplier : GXProcedure
   {
      public purchaseordermodifybysupplier( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordermodifybysupplier( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           bool aP1_Option ,
                           GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP2_SDTPurchaseOrderDetails ,
                           string aP3_PurchaseOrderCanceledDescription )
      {
         this.AV11PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV9Option = aP1_Option;
         this.AV10SDTPurchaseOrderDetails = aP2_SDTPurchaseOrderDetails;
         this.AV17PurchaseOrderCanceledDescription = aP3_PurchaseOrderCanceledDescription;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 bool aP1_Option ,
                                 GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP2_SDTPurchaseOrderDetails ,
                                 string aP3_PurchaseOrderCanceledDescription )
      {
         purchaseordermodifybysupplier objpurchaseordermodifybysupplier;
         objpurchaseordermodifybysupplier = new purchaseordermodifybysupplier();
         objpurchaseordermodifybysupplier.AV11PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseordermodifybysupplier.AV9Option = aP1_Option;
         objpurchaseordermodifybysupplier.AV10SDTPurchaseOrderDetails = aP2_SDTPurchaseOrderDetails;
         objpurchaseordermodifybysupplier.AV17PurchaseOrderCanceledDescription = aP3_PurchaseOrderCanceledDescription;
         objpurchaseordermodifybysupplier.context.SetSubmitInitialConfig(context);
         objpurchaseordermodifybysupplier.initialize();
         Submit( executePrivateCatch,objpurchaseordermodifybysupplier);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordermodifybysupplier)stateInfo).executePrivate();
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
         if ( AV9Option )
         {
            /* Execute user subroutine: 'CONFIRM' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'CANCEL' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CONFIRM' Routine */
         returnInSub = false;
         /* Using cursor P00302 */
         pr_default.execute(0, new Object[] {AV11PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A50PurchaseOrderId = P00302_A50PurchaseOrderId[0];
            A135PurchaseOrderConfirmatedDate = P00302_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = P00302_n135PurchaseOrderConfirmatedDate[0];
            /* Using cursor P00303 */
            pr_default.execute(1, new Object[] {A50PurchaseOrderId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A15ProductId = P00303_A15ProductId[0];
               A77PurchaseOrderDetailQuantityRec = P00303_A77PurchaseOrderDetailQuantityRec[0];
               A85ProductCostPrice = P00303_A85ProductCostPrice[0];
               n85ProductCostPrice = P00303_n85ProductCostPrice[0];
               A134PurchaseOrderDetailSuggestedPr = P00303_A134PurchaseOrderDetailSuggestedPr[0];
               n134PurchaseOrderDetailSuggestedPr = P00303_n134PurchaseOrderDetailSuggestedPr[0];
               A61PurchaseOrderDetailId = P00303_A61PurchaseOrderDetailId[0];
               A85ProductCostPrice = P00303_A85ProductCostPrice[0];
               n85ProductCostPrice = P00303_n85ProductCostPrice[0];
               AV12ProductId = A15ProductId;
               /* Execute user subroutine: 'GETDATA' */
               S123 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               A77PurchaseOrderDetailQuantityRec = AV13PurchaseOrderDetailQuantityOrdered;
               A134PurchaseOrderDetailSuggestedPr = ((AV15PurchaseOrderDetailSuggestedPrice>Convert.ToDecimal(0)) ? AV15PurchaseOrderDetailSuggestedPrice : A85ProductCostPrice);
               n134PurchaseOrderDetailSuggestedPr = false;
               /* Using cursor P00304 */
               pr_default.execute(2, new Object[] {A77PurchaseOrderDetailQuantityRec, n134PurchaseOrderDetailSuggestedPr, A134PurchaseOrderDetailSuggestedPr, A50PurchaseOrderId, A61PurchaseOrderDetailId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            A135PurchaseOrderConfirmatedDate = DateTimeUtil.ServerDate( context, pr_default);
            n135PurchaseOrderConfirmatedDate = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P00305 */
            pr_default.execute(3, new Object[] {n135PurchaseOrderConfirmatedDate, A135PurchaseOrderConfirmatedDate, A50PurchaseOrderId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
            if (true) break;
            /* Using cursor P00306 */
            pr_default.execute(4, new Object[] {n135PurchaseOrderConfirmatedDate, A135PurchaseOrderConfirmatedDate, A50PurchaseOrderId});
            pr_default.close(4);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S123( )
      {
         /* 'GETDATA' Routine */
         returnInSub = false;
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV10SDTPurchaseOrderDetails.Count )
         {
            AV14SDTPurchaseOrderDetailsItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV10SDTPurchaseOrderDetails.Item(AV22GXV1));
            if ( AV14SDTPurchaseOrderDetailsItem.gxTpr_Id == AV12ProductId )
            {
               AV13PurchaseOrderDetailQuantityOrdered = AV14SDTPurchaseOrderDetailsItem.gxTpr_Quantityreceived;
               AV15PurchaseOrderDetailSuggestedPrice = AV14SDTPurchaseOrderDetailsItem.gxTpr_Newcostprice;
               if (true) break;
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'CANCEL' Routine */
         returnInSub = false;
         /* Using cursor P00307 */
         pr_default.execute(5, new Object[] {AV11PurchaseOrderId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A50PurchaseOrderId = P00307_A50PurchaseOrderId[0];
            A79PurchaseOrderActive = P00307_A79PurchaseOrderActive[0];
            A136PurchaseOrderCanceledDescripti = P00307_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = P00307_n136PurchaseOrderCanceledDescripti[0];
            A79PurchaseOrderActive = false;
            A136PurchaseOrderCanceledDescripti = StringUtil.LTrim( StringUtil.RTrim( AV17PurchaseOrderCanceledDescription));
            n136PurchaseOrderCanceledDescripti = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P00308 */
            pr_default.execute(6, new Object[] {A79PurchaseOrderActive, n136PurchaseOrderCanceledDescripti, A136PurchaseOrderCanceledDescripti, A50PurchaseOrderId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
            if (true) break;
            /* Using cursor P00309 */
            pr_default.execute(7, new Object[] {A79PurchaseOrderActive, n136PurchaseOrderCanceledDescripti, A136PurchaseOrderCanceledDescripti, A50PurchaseOrderId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
      }

      public override void cleanup( )
      {
         context.CommitDataStores("purchaseordermodifybysupplier",pr_default);
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
         P00302_A50PurchaseOrderId = new int[1] ;
         P00302_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         P00302_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         P00303_A50PurchaseOrderId = new int[1] ;
         P00303_A15ProductId = new int[1] ;
         P00303_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P00303_A85ProductCostPrice = new decimal[1] ;
         P00303_n85ProductCostPrice = new bool[] {false} ;
         P00303_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         P00303_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         P00303_A61PurchaseOrderDetailId = new int[1] ;
         AV14SDTPurchaseOrderDetailsItem = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         P00307_A50PurchaseOrderId = new int[1] ;
         P00307_A79PurchaseOrderActive = new bool[] {false} ;
         P00307_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         P00307_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         A136PurchaseOrderCanceledDescripti = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordermodifybysupplier__default(),
            new Object[][] {
                new Object[] {
               P00302_A50PurchaseOrderId, P00302_A135PurchaseOrderConfirmatedDate, P00302_n135PurchaseOrderConfirmatedDate
               }
               , new Object[] {
               P00303_A50PurchaseOrderId, P00303_A15ProductId, P00303_A77PurchaseOrderDetailQuantityRec, P00303_A85ProductCostPrice, P00303_n85ProductCostPrice, P00303_A134PurchaseOrderDetailSuggestedPr, P00303_n134PurchaseOrderDetailSuggestedPr, P00303_A61PurchaseOrderDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00307_A50PurchaseOrderId, P00307_A79PurchaseOrderActive, P00307_A136PurchaseOrderCanceledDescripti, P00307_n136PurchaseOrderCanceledDescripti
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

      private int AV11PurchaseOrderId ;
      private int A50PurchaseOrderId ;
      private int A15ProductId ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int A61PurchaseOrderDetailId ;
      private int AV12ProductId ;
      private int AV13PurchaseOrderDetailQuantityOrdered ;
      private int AV22GXV1 ;
      private decimal A85ProductCostPrice ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private decimal AV15PurchaseOrderDetailSuggestedPrice ;
      private string scmdbuf ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private bool AV9Option ;
      private bool returnInSub ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n85ProductCostPrice ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool A79PurchaseOrderActive ;
      private bool n136PurchaseOrderCanceledDescripti ;
      private string AV17PurchaseOrderCanceledDescription ;
      private string A136PurchaseOrderCanceledDescripti ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00302_A50PurchaseOrderId ;
      private DateTime[] P00302_A135PurchaseOrderConfirmatedDate ;
      private bool[] P00302_n135PurchaseOrderConfirmatedDate ;
      private int[] P00303_A50PurchaseOrderId ;
      private int[] P00303_A15ProductId ;
      private int[] P00303_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] P00303_A85ProductCostPrice ;
      private bool[] P00303_n85ProductCostPrice ;
      private decimal[] P00303_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] P00303_n134PurchaseOrderDetailSuggestedPr ;
      private int[] P00303_A61PurchaseOrderDetailId ;
      private int[] P00307_A50PurchaseOrderId ;
      private bool[] P00307_A79PurchaseOrderActive ;
      private string[] P00307_A136PurchaseOrderCanceledDescripti ;
      private bool[] P00307_n136PurchaseOrderCanceledDescripti ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV10SDTPurchaseOrderDetails ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV14SDTPurchaseOrderDetailsItem ;
   }

   public class purchaseordermodifybysupplier__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00302;
          prmP00302 = new Object[] {
          new ParDef("@AV11PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00303;
          prmP00303 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00304;
          prmP00304 = new Object[] {
          new ParDef("@PurchaseOrderDetailQuantityRec",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmP00305;
          prmP00305 = new Object[] {
          new ParDef("@PurchaseOrderConfirmatedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00306;
          prmP00306 = new Object[] {
          new ParDef("@PurchaseOrderConfirmatedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00307;
          prmP00307 = new Object[] {
          new ParDef("@AV11PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00308;
          prmP00308 = new Object[] {
          new ParDef("@PurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@PurchaseOrderCanceledDescripti",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00309;
          prmP00309 = new Object[] {
          new ParDef("@PurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@PurchaseOrderCanceledDescripti",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00302", "SELECT TOP 1 [PurchaseOrderId], [PurchaseOrderConfirmatedDate] FROM [PurchaseOrder] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @AV11PurchaseOrderId ORDER BY [PurchaseOrderId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00302,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00303", "SELECT T1.[PurchaseOrderId], T1.[ProductId], T1.[PurchaseOrderDetailQuantityRec], T2.[ProductCostPrice], T1.[PurchaseOrderDetailSuggestedPr], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 WITH (UPDLOCK) INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00303,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00304", "UPDATE [PurchaseOrderDetail] SET [PurchaseOrderDetailQuantityRec]=@PurchaseOrderDetailQuantityRec, [PurchaseOrderDetailSuggestedPr]=@PurchaseOrderDetailSuggestedPr  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00304)
             ,new CursorDef("P00305", "UPDATE [PurchaseOrder] SET [PurchaseOrderConfirmatedDate]=@PurchaseOrderConfirmatedDate  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00305)
             ,new CursorDef("P00306", "UPDATE [PurchaseOrder] SET [PurchaseOrderConfirmatedDate]=@PurchaseOrderConfirmatedDate  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00306)
             ,new CursorDef("P00307", "SELECT TOP 1 [PurchaseOrderId], [PurchaseOrderActive], [PurchaseOrderCanceledDescripti] FROM [PurchaseOrder] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @AV11PurchaseOrderId ORDER BY [PurchaseOrderId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00307,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00308", "UPDATE [PurchaseOrder] SET [PurchaseOrderActive]=@PurchaseOrderActive, [PurchaseOrderCanceledDescripti]=@PurchaseOrderCanceledDescripti  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00308)
             ,new CursorDef("P00309", "UPDATE [PurchaseOrder] SET [PurchaseOrderActive]=@PurchaseOrderActive, [PurchaseOrderCanceledDescripti]=@PurchaseOrderCanceledDescripti  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00309)
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
