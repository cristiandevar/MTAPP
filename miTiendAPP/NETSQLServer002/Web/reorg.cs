using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "[" + DataBaseName + "]";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  cmdBuffer = "ALTER DATABASE " + "[" + DataBaseName + "]" + " SET READ_COMMITTED_SNAPSHOT ON";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
               setupDB = 1;
               if ( ( setupDB == 1 ) || GeneXus.Configuration.Preferences.MustSetupDB( ) )
               {
                  defaultUsers = GXUtil.DefaultWebUser( context);
                  short gxidx;
                  gxidx = 1;
                  while ( gxidx <= defaultUsers.Count )
                  {
                     defaultUser = ((string)defaultUsers.Item(gxidx));
                     try
                     {
                        GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbadduser", new   object[]  {defaultUser, DataBaseName}) , null);
                        cmdBuffer = "CREATE LOGIN " + "[" + defaultUser + "]" + " FROM WINDOWS";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "CREATE USER " + "[" + defaultUser + "]" + " FOR LOGIN " + "[" + defaultUser + "]";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datareader', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datawriter', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     gxidx = (short)(gxidx+1);
                  }
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateInvoiceDetail( )
      {
         string cmdBuffer = "";
         /* Indices for table InvoiceDetail */
         try
         {
            cmdBuffer=" CREATE TABLE [InvoiceDetail] ([InvoiceId] int NOT NULL , [InvoiceDetailId] int NOT NULL , [InvoiceDetailQuantity] int NOT NULL , [InvoiceDetailHistoricPrice] money NOT NULL , [ProductId] int NOT NULL , PRIMARY KEY([InvoiceId], [InvoiceDetailId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[InvoiceDetail]") ;
               cmdBuffer=" DROP TABLE [InvoiceDetail] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[InvoiceDetail]") ;
                  cmdBuffer=" DROP VIEW [InvoiceDetail] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[InvoiceDetail]") ;
                     cmdBuffer=" DROP FUNCTION [InvoiceDetail] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [InvoiceDetail] ([InvoiceId] int NOT NULL , [InvoiceDetailId] int NOT NULL , [InvoiceDetailQuantity] int NOT NULL , [InvoiceDetailHistoricPrice] money NOT NULL , [ProductId] int NOT NULL , PRIMARY KEY([InvoiceId], [InvoiceDetailId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVOICEDETAIL1] ON [InvoiceDetail] ([ProductId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINVOICEDETAIL1] ON [InvoiceDetail] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVOICEDETAIL1] ON [InvoiceDetail] ([ProductId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePurchaseOrderDetail( )
      {
         string cmdBuffer = "";
         /* Indices for table PurchaseOrderDetail */
         try
         {
            cmdBuffer=" CREATE TABLE [PurchaseOrderDetail] ([PurchaseOrderId] int NOT NULL , [PurchaseOrderDetailId] int NOT NULL , [PurchaseOrderDetailQuantity] smallint NOT NULL , [ProductId] int NOT NULL , [PurchaseOrderDetailCurrentPric] money NOT NULL , [PurchaseOrderDetailSuggestedPr] money NOT NULL , PRIMARY KEY([PurchaseOrderId], [PurchaseOrderDetailId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[PurchaseOrderDetail]") ;
               cmdBuffer=" DROP TABLE [PurchaseOrderDetail] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[PurchaseOrderDetail]") ;
                  cmdBuffer=" DROP VIEW [PurchaseOrderDetail] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[PurchaseOrderDetail]") ;
                     cmdBuffer=" DROP FUNCTION [PurchaseOrderDetail] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [PurchaseOrderDetail] ([PurchaseOrderId] int NOT NULL , [PurchaseOrderDetailId] int NOT NULL , [PurchaseOrderDetailQuantity] smallint NOT NULL , [ProductId] int NOT NULL , [PurchaseOrderDetailCurrentPric] money NOT NULL , [PurchaseOrderDetailSuggestedPr] money NOT NULL , PRIMARY KEY([PurchaseOrderId], [PurchaseOrderDetailId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPURCHASEORDERDETAIL1] ON [PurchaseOrderDetail] ([ProductId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPURCHASEORDERDETAIL1] ON [PurchaseOrderDetail] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPURCHASEORDERDETAIL1] ON [PurchaseOrderDetail] ([ProductId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePurchaseOrder( )
      {
         string cmdBuffer = "";
         /* Indices for table PurchaseOrder */
         try
         {
            cmdBuffer=" CREATE TABLE [PurchaseOrder] ([PurchaseOrderId] int NOT NULL IDENTITY(1,1), [SupplierId] int NOT NULL , [PurchaseOrderCreatedDate] datetime NOT NULL , [PurchaseOrderModifiedDate] datetime NULL , [PurchaseOrderClosedDate] datetime NULL , PRIMARY KEY([PurchaseOrderId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[PurchaseOrder]") ;
               cmdBuffer=" DROP TABLE [PurchaseOrder] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[PurchaseOrder]") ;
                  cmdBuffer=" DROP VIEW [PurchaseOrder] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[PurchaseOrder]") ;
                     cmdBuffer=" DROP FUNCTION [PurchaseOrder] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [PurchaseOrder] ([PurchaseOrderId] int NOT NULL IDENTITY(1,1), [SupplierId] int NOT NULL , [PurchaseOrderCreatedDate] datetime NOT NULL , [PurchaseOrderModifiedDate] datetime NULL , [PurchaseOrderClosedDate] datetime NULL , PRIMARY KEY([PurchaseOrderId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPURCHASEORDER1] ON [PurchaseOrder] ([SupplierId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPURCHASEORDER1] ON [PurchaseOrder] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPURCHASEORDER1] ON [PurchaseOrder] ([SupplierId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateInvoice( )
      {
         string cmdBuffer = "";
         /* Indices for table Invoice */
         try
         {
            cmdBuffer=" CREATE TABLE [Invoice] ([InvoiceId] int NOT NULL IDENTITY(1,1), [InvoiceDate] datetime NOT NULL , [EmployeeId] int NOT NULL , [InvoiceCreatedDate] datetime NOT NULL , [InvoiceModifiedDate] datetime NULL , PRIMARY KEY([InvoiceId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Invoice]") ;
               cmdBuffer=" DROP TABLE [Invoice] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Invoice]") ;
                  cmdBuffer=" DROP VIEW [Invoice] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Invoice]") ;
                     cmdBuffer=" DROP FUNCTION [Invoice] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Invoice] ([InvoiceId] int NOT NULL IDENTITY(1,1), [InvoiceDate] datetime NOT NULL , [EmployeeId] int NOT NULL , [InvoiceCreatedDate] datetime NOT NULL , [InvoiceModifiedDate] datetime NULL , PRIMARY KEY([InvoiceId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVOICE1] ON [Invoice] ([EmployeeId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINVOICE1] ON [Invoice] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVOICE1] ON [Invoice] ([EmployeeId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProduct( )
      {
         string cmdBuffer = "";
         /* Indices for table Product */
         try
         {
            cmdBuffer=" CREATE TABLE [Product] ([ProductId] int NOT NULL IDENTITY(1,1), [ProductName] nvarchar(60) NOT NULL , [ProductStock] int NOT NULL , [ProductPrice] money NOT NULL , [ProductDescription] nvarchar(200) NULL , [BrandId] int NOT NULL , [SectorId] int NOT NULL , [SupplierId] int NOT NULL , [ProductCreatedDate] datetime NOT NULL , [ProductModifiedDate] datetime NULL , [ProductCode] nvarchar(100) NULL , PRIMARY KEY([ProductId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Product]") ;
               cmdBuffer=" DROP TABLE [Product] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Product]") ;
                  cmdBuffer=" DROP VIEW [Product] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Product]") ;
                     cmdBuffer=" DROP FUNCTION [Product] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Product] ([ProductId] int NOT NULL IDENTITY(1,1), [ProductName] nvarchar(60) NOT NULL , [ProductStock] int NOT NULL , [ProductPrice] money NOT NULL , [ProductDescription] nvarchar(200) NULL , [BrandId] int NOT NULL , [SectorId] int NOT NULL , [SupplierId] int NOT NULL , [ProductCreatedDate] datetime NOT NULL , [ProductModifiedDate] datetime NULL , [ProductCode] nvarchar(100) NULL , PRIMARY KEY([ProductId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUCT1] ON [Product] ([SupplierId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRODUCT1] ON [Product] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUCT1] ON [Product] ([SupplierId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUCT2] ON [Product] ([SectorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRODUCT2] ON [Product] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUCT2] ON [Product] ([SectorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUCT3] ON [Product] ([BrandId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRODUCT3] ON [Product] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUCT3] ON [Product] ([BrandId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEmployee( )
      {
         string cmdBuffer = "";
         /* Indices for table Employee */
         try
         {
            cmdBuffer=" CREATE TABLE [Employee] ([EmployeeId] int NOT NULL IDENTITY(1,1), [EmployeeFirstName] nvarchar(60) NOT NULL , [EmployeeLastName] nvarchar(60) NOT NULL , [EmployeeCreatedDate] datetime NOT NULL , [EmployeeModifiedDate] datetime NOT NULL , PRIMARY KEY([EmployeeId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Employee]") ;
               cmdBuffer=" DROP TABLE [Employee] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Employee]") ;
                  cmdBuffer=" DROP VIEW [Employee] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Employee]") ;
                     cmdBuffer=" DROP FUNCTION [Employee] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Employee] ([EmployeeId] int NOT NULL IDENTITY(1,1), [EmployeeFirstName] nvarchar(60) NOT NULL , [EmployeeLastName] nvarchar(60) NOT NULL , [EmployeeCreatedDate] datetime NOT NULL , [EmployeeModifiedDate] datetime NOT NULL , PRIMARY KEY([EmployeeId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSector( )
      {
         string cmdBuffer = "";
         /* Indices for table Sector */
         try
         {
            cmdBuffer=" CREATE TABLE [Sector] ([SectorId] int NOT NULL IDENTITY(1,1), [SectorName] nvarchar(60) NOT NULL , [SectorDescription] nvarchar(200) NULL , [SectorCreatedDate] datetime NOT NULL , [SectorModifiedDate] datetime NULL , PRIMARY KEY([SectorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Sector]") ;
               cmdBuffer=" DROP TABLE [Sector] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Sector]") ;
                  cmdBuffer=" DROP VIEW [Sector] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Sector]") ;
                     cmdBuffer=" DROP FUNCTION [Sector] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Sector] ([SectorId] int NOT NULL IDENTITY(1,1), [SectorName] nvarchar(60) NOT NULL , [SectorDescription] nvarchar(200) NULL , [SectorCreatedDate] datetime NOT NULL , [SectorModifiedDate] datetime NULL , PRIMARY KEY([SectorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateSupplier( )
      {
         string cmdBuffer = "";
         /* Indices for table Supplier */
         try
         {
            cmdBuffer=" CREATE TABLE [Supplier] ([SupplierId] int NOT NULL IDENTITY(1,1), [SupplierName] nvarchar(60) NOT NULL , [SupplierDescription] nvarchar(200) NULL , [SupplierPhone] nchar(20) NULL , [SupplierEmail] nvarchar(100) NULL , [SupplierCreatedDate] datetime NOT NULL , [SupplierModifiedDate] datetime NOT NULL , PRIMARY KEY([SupplierId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Supplier]") ;
               cmdBuffer=" DROP TABLE [Supplier] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Supplier]") ;
                  cmdBuffer=" DROP VIEW [Supplier] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Supplier]") ;
                     cmdBuffer=" DROP FUNCTION [Supplier] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Supplier] ([SupplierId] int NOT NULL IDENTITY(1,1), [SupplierName] nvarchar(60) NOT NULL , [SupplierDescription] nvarchar(200) NULL , [SupplierPhone] nchar(20) NULL , [SupplierEmail] nvarchar(100) NULL , [SupplierCreatedDate] datetime NOT NULL , [SupplierModifiedDate] datetime NOT NULL , PRIMARY KEY([SupplierId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateBrand( )
      {
         string cmdBuffer = "";
         /* Indices for table Brand */
         try
         {
            cmdBuffer=" CREATE TABLE [Brand] ([BrandId] int NOT NULL IDENTITY(1,1), [BrandName] nvarchar(60) NOT NULL , [BrandDescription] nvarchar(200) NULL , [BrandCreatedDate] datetime NOT NULL , [BrandModifiedDate] datetime NULL , PRIMARY KEY([BrandId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Brand]") ;
               cmdBuffer=" DROP TABLE [Brand] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Brand]") ;
                  cmdBuffer=" DROP VIEW [Brand] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Brand]") ;
                     cmdBuffer=" DROP FUNCTION [Brand] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Brand] ([BrandId] int NOT NULL IDENTITY(1,1), [BrandName] nvarchar(60) NOT NULL , [BrandDescription] nvarchar(200) NULL , [BrandCreatedDate] datetime NOT NULL , [BrandModifiedDate] datetime NULL , PRIMARY KEY([BrandId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProductBrand( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT3] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([BrandId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Product] DROP CONSTRAINT [IPRODUCT3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT3] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([BrandId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProductSector( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT2] FOREIGN KEY ([SectorId]) REFERENCES [Sector] ([SectorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Product] DROP CONSTRAINT [IPRODUCT2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT2] FOREIGN KEY ([SectorId]) REFERENCES [Sector] ([SectorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProductSupplier( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT1] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Product] DROP CONSTRAINT [IPRODUCT1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Product] ADD CONSTRAINT [IPRODUCT1] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInvoiceEmployee( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Invoice] ADD CONSTRAINT [IINVOICE1] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([EmployeeId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Invoice] DROP CONSTRAINT [IINVOICE1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Invoice] ADD CONSTRAINT [IINVOICE1] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([EmployeeId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPurchaseOrderSupplier( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PurchaseOrder] ADD CONSTRAINT [IPURCHASEORDER1] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PurchaseOrder] DROP CONSTRAINT [IPURCHASEORDER1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PurchaseOrder] ADD CONSTRAINT [IPURCHASEORDER1] FOREIGN KEY ([SupplierId]) REFERENCES [Supplier] ([SupplierId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPurchaseOrderDetailPurchaseOrder( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PurchaseOrderDetail] ADD CONSTRAINT [IPURCHASEORDERDETAIL2] FOREIGN KEY ([PurchaseOrderId]) REFERENCES [PurchaseOrder] ([PurchaseOrderId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PurchaseOrderDetail] DROP CONSTRAINT [IPURCHASEORDERDETAIL2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PurchaseOrderDetail] ADD CONSTRAINT [IPURCHASEORDERDETAIL2] FOREIGN KEY ([PurchaseOrderId]) REFERENCES [PurchaseOrder] ([PurchaseOrderId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPurchaseOrderDetailProduct( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PurchaseOrderDetail] ADD CONSTRAINT [IPURCHASEORDERDETAIL1] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PurchaseOrderDetail] DROP CONSTRAINT [IPURCHASEORDERDETAIL1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PurchaseOrderDetail] ADD CONSTRAINT [IPURCHASEORDERDETAIL1] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInvoiceDetailInvoice( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [InvoiceDetail] ADD CONSTRAINT [IINVOICEDETAIL2] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([InvoiceId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [InvoiceDetail] DROP CONSTRAINT [IINVOICEDETAIL2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [InvoiceDetail] ADD CONSTRAINT [IINVOICEDETAIL2] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([InvoiceId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInvoiceDetailProduct( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [InvoiceDetail] ADD CONSTRAINT [IINVOICEDETAIL1] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [InvoiceDetail] DROP CONSTRAINT [IINVOICEDETAIL1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [InvoiceDetail] ADD CONSTRAINT [IINVOICEDETAIL1] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               sSchemaVar = P00012_AsSchemaVar[0];
               nsSchemaVar = P00012_nsSchemaVar[0];
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               sSchemaVar = P00023_AsSchemaVar[0];
               nsSchemaVar = P00023_nsSchemaVar[0];
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         return true ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateInvoiceDetail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreatePurchaseOrderDetail" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreatePurchaseOrder" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateInvoice" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateProduct" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateEmployee" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateSector" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateSupplier" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateBrand" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "RIProductBrand" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "RIProductSector" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "RIProductSupplier" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "RIInvoiceEmployee" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "RIPurchaseOrderSupplier" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "RIPurchaseOrderDetailPurchaseOrder" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "RIPurchaseOrderDetailProduct" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "RIInvoiceDetailInvoice" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "RIInvoiceDetailProduct" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"InvoiceDetail", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateInvoiceDetail" ,  "CreateInvoice" );
         ReorgExecute.RegisterPrecedence( "CreateInvoiceDetail" ,  "CreateProduct" );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PurchaseOrderDetail", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePurchaseOrderDetail" ,  "CreatePurchaseOrder" );
         ReorgExecute.RegisterPrecedence( "CreatePurchaseOrderDetail" ,  "CreateProduct" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PurchaseOrder", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePurchaseOrder" ,  "CreateSupplier" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Invoice", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateInvoice" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Product", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateProduct" ,  "CreateBrand" );
         ReorgExecute.RegisterPrecedence( "CreateProduct" ,  "CreateSector" );
         ReorgExecute.RegisterPrecedence( "CreateProduct" ,  "CreateSupplier" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Employee", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Sector", ""}) );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Supplier", ""}) );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Brand", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRODUCT3]"}) );
         ReorgExecute.RegisterPrecedence( "RIProductBrand" ,  "CreateProduct" );
         ReorgExecute.RegisterPrecedence( "RIProductBrand" ,  "CreateBrand" );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRODUCT2]"}) );
         ReorgExecute.RegisterPrecedence( "RIProductSector" ,  "CreateProduct" );
         ReorgExecute.RegisterPrecedence( "RIProductSector" ,  "CreateSector" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRODUCT1]"}) );
         ReorgExecute.RegisterPrecedence( "RIProductSupplier" ,  "CreateProduct" );
         ReorgExecute.RegisterPrecedence( "RIProductSupplier" ,  "CreateSupplier" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVOICE1]"}) );
         ReorgExecute.RegisterPrecedence( "RIInvoiceEmployee" ,  "CreateInvoice" );
         ReorgExecute.RegisterPrecedence( "RIInvoiceEmployee" ,  "CreateEmployee" );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPURCHASEORDER1]"}) );
         ReorgExecute.RegisterPrecedence( "RIPurchaseOrderSupplier" ,  "CreatePurchaseOrder" );
         ReorgExecute.RegisterPrecedence( "RIPurchaseOrderSupplier" ,  "CreateSupplier" );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPURCHASEORDERDETAIL2]"}) );
         ReorgExecute.RegisterPrecedence( "RIPurchaseOrderDetailPurchaseOrder" ,  "CreatePurchaseOrderDetail" );
         ReorgExecute.RegisterPrecedence( "RIPurchaseOrderDetailPurchaseOrder" ,  "CreatePurchaseOrder" );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPURCHASEORDERDETAIL1]"}) );
         ReorgExecute.RegisterPrecedence( "RIPurchaseOrderDetailProduct" ,  "CreatePurchaseOrderDetail" );
         ReorgExecute.RegisterPrecedence( "RIPurchaseOrderDetailProduct" ,  "CreateProduct" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVOICEDETAIL2]"}) );
         ReorgExecute.RegisterPrecedence( "RIInvoiceDetailInvoice" ,  "CreateInvoiceDetail" );
         ReorgExecute.RegisterPrecedence( "RIInvoiceDetailInvoice" ,  "CreateInvoice" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVOICEDETAIL1]"}) );
         ReorgExecute.RegisterPrecedence( "RIInvoiceDetailProduct" ,  "CreateInvoiceDetail" );
         ReorgExecute.RegisterPrecedence( "RIInvoiceDetailProduct" ,  "CreateProduct" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void DropTableConstraints( string sTableName )
      {
         string cmdBuffer;
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            constid = P00034_Aconstid[0];
            nconstid = P00034_nconstid[0];
            fkeyid = P00034_Afkeyid[0];
            nfkeyid = P00034_nfkeyid[0];
            rkeyid = P00034_Arkeyid[0];
            nrkeyid = P00034_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         defaultUsers = new GeneXus.Utils.GxStringCollection();
         defaultUser = "";
         sSchemaVar = "";
         nsSchemaVar = false;
         scmdbuf = "";
         P00012_AsSchemaVar = new string[] {""} ;
         P00012_nsSchemaVar = new bool[] {false} ;
         P00023_AsSchemaVar = new string[] {""} ;
         P00023_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00034_Aconstid = new string[] {""} ;
         P00034_nconstid = new bool[] {false} ;
         P00034_Afkeyid = new string[] {""} ;
         P00034_nfkeyid = new bool[] {false} ;
         P00034_Arkeyid = new int[1] ;
         P00034_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_AsSchemaVar
               }
               , new Object[] {
               P00023_AsSchemaVar
               }
               , new Object[] {
               P00034_Aconstid, P00034_Afkeyid, P00034_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected short setupDB ;
      protected int rkeyid ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string defaultUser ;
      protected string sSchemaVar ;
      protected string scmdbuf ;
      protected string sTableName ;
      protected bool nsSchemaVar ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected string constid ;
      protected string fkeyid ;
      protected GeneXus.Utils.GxStringCollection defaultUsers ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_AsSchemaVar ;
      protected bool[] P00012_nsSchemaVar ;
      protected string[] P00023_AsSchemaVar ;
      protected bool[] P00023_nsSchemaVar ;
      protected string[] P00034_Aconstid ;
      protected bool[] P00034_nconstid ;
      protected string[] P00034_Afkeyid ;
      protected bool[] P00034_nfkeyid ;
      protected int[] P00034_Arkeyid ;
      protected bool[] P00034_nrkeyid ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), referenced_object_id FROM sys.foreign_keys WHERE referenced_object_id = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
