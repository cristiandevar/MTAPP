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
   public class user_resetpassword : GXProcedure
   {
      public user_resetpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public user_resetpassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UserId ,
                           out bool aP1_AllOk )
      {
         this.AV12UserId = aP0_UserId;
         this.AV13AllOk = false ;
         initialize();
         executePrivate();
         aP1_AllOk=this.AV13AllOk;
      }

      public bool executeUdp( int aP0_UserId )
      {
         execute(aP0_UserId, out aP1_AllOk);
         return AV13AllOk ;
      }

      public void executeSubmit( int aP0_UserId ,
                                 out bool aP1_AllOk )
      {
         user_resetpassword objuser_resetpassword;
         objuser_resetpassword = new user_resetpassword();
         objuser_resetpassword.AV12UserId = aP0_UserId;
         objuser_resetpassword.AV13AllOk = false ;
         objuser_resetpassword.context.SetSubmitInitialConfig(context);
         objuser_resetpassword.initialize();
         Submit( executePrivateCatch,objuser_resetpassword);
         aP1_AllOk=this.AV13AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((user_resetpassword)stateInfo).executePrivate();
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
         /* Using cursor P00272 */
         pr_default.execute(0, new Object[] {AV12UserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A99UserId = P00272_A99UserId[0];
            A100UserName = P00272_A100UserName[0];
            A101UserPassword = P00272_A101UserPassword[0];
            A109UserHash = P00272_A109UserHash[0];
            AV9UserHash = Crypto.GetEncryptionKey( );
            A101UserPassword = Encrypt64( A100UserName, AV9UserHash);
            A109UserHash = AV9UserHash;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P00273 */
            pr_default.execute(1, new Object[] {A101UserPassword, A109UserHash, A99UserId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("User");
            if (true) break;
            /* Using cursor P00274 */
            pr_default.execute(2, new Object[] {A101UserPassword, A109UserHash, A99UserId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("User");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("user_resetpassword",pr_default);
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
         P00272_A99UserId = new int[1] ;
         P00272_A100UserName = new string[] {""} ;
         P00272_A101UserPassword = new string[] {""} ;
         P00272_A109UserHash = new string[] {""} ;
         A100UserName = "";
         A101UserPassword = "";
         A109UserHash = "";
         AV9UserHash = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.user_resetpassword__default(),
            new Object[][] {
                new Object[] {
               P00272_A99UserId, P00272_A100UserName, P00272_A101UserPassword, P00272_A109UserHash
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

      private int AV12UserId ;
      private int A99UserId ;
      private string scmdbuf ;
      private bool AV13AllOk ;
      private string A100UserName ;
      private string A101UserPassword ;
      private string A109UserHash ;
      private string AV9UserHash ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00272_A99UserId ;
      private string[] P00272_A100UserName ;
      private string[] P00272_A101UserPassword ;
      private string[] P00272_A109UserHash ;
      private bool aP1_AllOk ;
   }

   public class user_resetpassword__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00272;
          prmP00272 = new Object[] {
          new ParDef("@AV12UserId",GXType.Int32,6,0)
          };
          Object[] prmP00273;
          prmP00273 = new Object[] {
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmP00274;
          prmP00274 = new Object[] {
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00272", "SELECT TOP 1 [UserId], [UserName], [UserPassword], [UserHash] FROM [User] WITH (UPDLOCK) WHERE [UserId] = @AV12UserId ORDER BY [UserId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00272,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00273", "UPDATE [User] SET [UserPassword]=@UserPassword, [UserHash]=@UserHash  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00273)
             ,new CursorDef("P00274", "UPDATE [User] SET [UserPassword]=@UserPassword, [UserHash]=@UserHash  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00274)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
