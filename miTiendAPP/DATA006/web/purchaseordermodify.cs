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
   public class purchaseordermodify : GXProcedure
   {
      public purchaseordermodify( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordermodify( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           ref GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_DetailsEdit ,
                           out bool aP2_AllOk )
      {
         this.A50PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV9DetailsEdit = aP1_DetailsEdit;
         this.AV8AllOk = false ;
         initialize();
         executePrivate();
         aP1_DetailsEdit=this.AV9DetailsEdit;
         aP2_AllOk=this.AV8AllOk;
      }

      public bool executeUdp( int aP0_PurchaseOrderId ,
                              ref GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_DetailsEdit )
      {
         execute(aP0_PurchaseOrderId, ref aP1_DetailsEdit, out aP2_AllOk);
         return AV8AllOk ;
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 ref GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_DetailsEdit ,
                                 out bool aP2_AllOk )
      {
         purchaseordermodify objpurchaseordermodify;
         objpurchaseordermodify = new purchaseordermodify();
         objpurchaseordermodify.A50PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseordermodify.AV9DetailsEdit = aP1_DetailsEdit;
         objpurchaseordermodify.AV8AllOk = false ;
         objpurchaseordermodify.context.SetSubmitInitialConfig(context);
         objpurchaseordermodify.initialize();
         Submit( executePrivateCatch,objpurchaseordermodify);
         aP1_DetailsEdit=this.AV9DetailsEdit;
         aP2_AllOk=this.AV8AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordermodify)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV21Context, ref  AV8AllOk) ;
         if ( ! AV8AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV8AllOk = true;
         AV24GXV1 = 1;
         while ( AV24GXV1 <= AV9DetailsEdit.Count )
         {
            AV12OneNewDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV9DetailsEdit.Item(AV24GXV1));
            AV13ProductIds.Add(AV12OneNewDetail.gxTpr_Id, 0);
            AV24GXV1 = (int)(AV24GXV1+1);
         }
         AV20PositionOldDetail = 1;
         /* Using cursor P001C2 */
         pr_default.execute(0, new Object[] {A50PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15ProductId = P001C2_A15ProductId[0];
            A76PurchaseOrderDetailQuantityOrd = P001C2_A76PurchaseOrderDetailQuantityOrd[0];
            A61PurchaseOrderDetailId = P001C2_A61PurchaseOrderDetailId[0];
            AV19ProductId = A15ProductId;
            /* Execute user subroutine: 'SEARCHPOSITION' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( AV16PositionNewDetail != -1 )
            {
               AV12OneNewDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
               AV12OneNewDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV9DetailsEdit.Item(AV16PositionNewDetail));
               A76PurchaseOrderDetailQuantityOrd = AV12OneNewDetail.gxTpr_Quantityordered;
               AV9DetailsEdit.RemoveItem(AV16PositionNewDetail);
               AV13ProductIds.RemoveItem(AV16PositionNewDetail);
            }
            else
            {
               AV15OneId = A61PurchaseOrderDetailId;
               /* Execute user subroutine: 'DELETEDETAIL' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( ! AV8AllOk )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P001C3 */
               pr_default.execute(1, new Object[] {A76PurchaseOrderDetailQuantityOrd, A50PurchaseOrderId, A61PurchaseOrderDetailId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
               if (true) break;
            }
            AV20PositionOldDetail = (short)(AV20PositionOldDetail+1);
            /* Using cursor P001C4 */
            pr_default.execute(2, new Object[] {A76PurchaseOrderDetailQuantityOrd, A50PurchaseOrderId, A61PurchaseOrderDetailId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ( AV9DetailsEdit.Count > 0 ) && AV8AllOk )
         {
            /* Execute user subroutine: 'ADDNEWDETAILS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV18Order.Update();
            if ( AV18Order.Success() )
            {
               context.CommitDataStores("purchaseordermodify",pr_default);
            }
            else
            {
               context.RollbackDataStores("purchaseordermodify",pr_default);
               AV8AllOk = false;
               GX_msglist.addItem("Purchase Order Update Failed "+AV18Order.GetMessages().ToJSonString(false));
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SEARCHPOSITION' Routine */
         returnInSub = false;
         if ( AV13ProductIds.Count <= 0 )
         {
            AV16PositionNewDetail = -1;
         }
         else
         {
            AV16PositionNewDetail = 1;
            AV26GXV2 = 1;
            while ( AV26GXV2 <= AV13ProductIds.Count )
            {
               AV15OneId = (int)(AV13ProductIds.GetNumeric(AV26GXV2));
               if ( AV19ProductId == AV15OneId )
               {
                  if (true) break;
               }
               AV16PositionNewDetail = (short)(AV16PositionNewDetail+1);
               AV26GXV2 = (int)(AV26GXV2+1);
            }
            if ( AV16PositionNewDetail > AV13ProductIds.Count )
            {
               AV16PositionNewDetail = -1;
            }
         }
      }

      protected void S121( )
      {
         /* 'DELETEDETAIL' Routine */
         returnInSub = false;
         AV18Order = new SdtPurchaseOrder(context);
         AV18Order.Load(A50PurchaseOrderId);
         AV18Order.gxTpr_Detail.RemoveItem(AV20PositionOldDetail);
         AV18Order.Update();
         if ( AV18Order.Success() )
         {
            context.CommitDataStores("purchaseordermodify",pr_default);
         }
         else
         {
            context.RollbackDataStores("purchaseordermodify",pr_default);
            GX_msglist.addItem("Delete fail, Position:"+AV20PositionOldDetail+" Msg: "+AV18Order.GetMessages().ToJSonString(false));
            AV8AllOk = false;
         }
      }

      protected void S131( )
      {
         /* 'ADDNEWDETAILS' Routine */
         returnInSub = false;
         AV18Order = new SdtPurchaseOrder(context);
         AV18Order.Load(A50PurchaseOrderId);
         AV27GXV3 = 1;
         while ( AV27GXV3 <= AV9DetailsEdit.Count )
         {
            AV12OneNewDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV9DetailsEdit.Item(AV27GXV3));
            AV10OneDetail = new SdtPurchaseOrder_Detail(context);
            AV10OneDetail.gxTpr_Productid = AV12OneNewDetail.gxTpr_Id;
            AV10OneDetail.gxTpr_Purchaseorderdetailquantityordered = AV12OneNewDetail.gxTpr_Quantityordered;
            AV18Order.gxTpr_Detail.Add(AV10OneDetail, 0);
            AV27GXV3 = (int)(AV27GXV3+1);
         }
         AV18Order.Update();
         if ( AV18Order.Success() )
         {
            GX_msglist.addItem("Add new details success");
            context.CommitDataStores("purchaseordermodify",pr_default);
         }
         else
         {
            context.RollbackDataStores("purchaseordermodify",pr_default);
            GX_msglist.addItem("Add new details fail Msg: "+AV18Order.GetMessages().ToJSonString(false));
            AV8AllOk = false;
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("purchaseordermodify",pr_default);
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
         AV21Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV12OneNewDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         AV13ProductIds = new GxSimpleCollection<int>();
         scmdbuf = "";
         P001C2_A50PurchaseOrderId = new int[1] ;
         P001C2_A15ProductId = new int[1] ;
         P001C2_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P001C2_A61PurchaseOrderDetailId = new int[1] ;
         AV18Order = new SdtPurchaseOrder(context);
         AV10OneDetail = new SdtPurchaseOrder_Detail(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordermodify__default(),
            new Object[][] {
                new Object[] {
               P001C2_A50PurchaseOrderId, P001C2_A15ProductId, P001C2_A76PurchaseOrderDetailQuantityOrd, P001C2_A61PurchaseOrderDetailId
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

      private short AV20PositionOldDetail ;
      private short AV16PositionNewDetail ;
      private int A50PurchaseOrderId ;
      private int AV24GXV1 ;
      private int A15ProductId ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A61PurchaseOrderDetailId ;
      private int AV19ProductId ;
      private int AV15OneId ;
      private int AV26GXV2 ;
      private int AV27GXV3 ;
      private string scmdbuf ;
      private bool AV8AllOk ;
      private bool returnInSub ;
      private GxSimpleCollection<int> AV13ProductIds ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_DetailsEdit ;
      private IDataStoreProvider pr_default ;
      private int[] P001C2_A50PurchaseOrderId ;
      private int[] P001C2_A15ProductId ;
      private int[] P001C2_A76PurchaseOrderDetailQuantityOrd ;
      private int[] P001C2_A61PurchaseOrderDetailId ;
      private bool aP2_AllOk ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV9DetailsEdit ;
      private SdtPurchaseOrder AV18Order ;
      private SdtPurchaseOrder_Detail AV10OneDetail ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV12OneNewDetail ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV21Context ;
   }

   public class purchaseordermodify__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001C2;
          prmP001C2 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001C3;
          prmP001C3 = new Object[] {
          new ParDef("@PurchaseOrderDetailQuantityOrd",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmP001C4;
          prmP001C4 = new Object[] {
          new ParDef("@PurchaseOrderDetailQuantityOrd",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001C2", "SELECT [PurchaseOrderId], [ProductId], [PurchaseOrderDetailQuantityOrd], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId ORDER BY [PurchaseOrderId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001C3", "UPDATE [PurchaseOrderDetail] SET [PurchaseOrderDetailQuantityOrd]=@PurchaseOrderDetailQuantityOrd  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001C3)
             ,new CursorDef("P001C4", "UPDATE [PurchaseOrderDetail] SET [PurchaseOrderDetailQuantityOrd]=@PurchaseOrderDetailQuantityOrd  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001C4)
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
