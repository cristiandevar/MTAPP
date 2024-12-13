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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportwwpermission : GXProcedure
   {
      public exportwwpermission( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public exportwwpermission( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_PermissionName ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV18PermissionName = aP0_PermissionName;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( string aP0_PermissionName ,
                                out string aP1_Filename )
      {
         execute(aP0_PermissionName, out aP1_Filename, out aP2_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( string aP0_PermissionName ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         exportwwpermission objexportwwpermission;
         objexportwwpermission = new exportwwpermission();
         objexportwwpermission.AV18PermissionName = aP0_PermissionName;
         objexportwwpermission.AV10Filename = "" ;
         objexportwwpermission.AV11ErrorMessage = "" ;
         objexportwwpermission.context.SetSubmitInitialConfig(context);
         objexportwwpermission.initialize();
         Submit( executePrivateCatch,objexportwwpermission);
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwpermission)stateInfo).executePrivate();
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
         AV14Random = (int)(NumberUtil.Random( )*10000);
         AV10Filename = "Permission - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
         AV9ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV9ExcelDocument.Clear();
         AV12CellRow = 1;
         AV13FirstColumn = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Name";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV18PermissionName ,
                                              A107PermissionName } ,
                                              new int[]{
                                              }
         });
         lV18PermissionName = StringUtil.Concat( StringUtil.RTrim( AV18PermissionName), "%", "");
         /* Using cursor P001Y2 */
         pr_default.execute(0, new Object[] {lV18PermissionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107PermissionName = P001Y2_A107PermissionName[0];
            A106PermissionId = P001Y2_A106PermissionId[0];
            AV12CellRow = (int)(AV12CellRow+1);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = A107PermissionName;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV9ExcelDocument.Close();
         if ( AV16StorageProvider.GetPrivate(AV10Filename, AV15File, 1, AV17Messages) )
         {
            AV10Filename = AV15File.GetURI();
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV9ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV11ErrorMessage = AV9ExcelDocument.ErrDescription;
            AV9ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV9ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         lV18PermissionName = "";
         A107PermissionName = "";
         P001Y2_A107PermissionName = new string[] {""} ;
         P001Y2_A106PermissionId = new int[1] ;
         AV15File = new GxFile(context.GetPhysicalPath());
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16StorageProvider = new GxStorageProvider();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwpermission__default(),
            new Object[][] {
                new Object[] {
               P001Y2_A107PermissionName, P001Y2_A106PermissionId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV14Random ;
      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int A106PermissionId ;
      private string scmdbuf ;
      private bool returnInSub ;
      private string AV18PermissionName ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string lV18PermissionName ;
      private string A107PermissionName ;
      private GxStorageProvider AV16StorageProvider ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001Y2_A107PermissionName ;
      private int[] P001Y2_A106PermissionId ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GxFile AV15File ;
   }

   public class exportwwpermission__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001Y2( IGxContext context ,
                                             string AV18PermissionName ,
                                             string A107PermissionName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PermissionName], [PermissionId] FROM [Permission]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PermissionName)) )
         {
            AddWhere(sWhereString, "([PermissionName] like @lV18PermissionName)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PermissionName]";
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
                     return conditional_P001Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP001Y2;
          prmP001Y2 = new Object[] {
          new ParDef("@lV18PermissionName",GXType.NVarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Y2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
