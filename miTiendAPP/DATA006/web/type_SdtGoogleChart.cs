/*
				   File: type_SdtGoogleChart
			Description: GoogleChart
				 Author: Nemo 🐠 for C# (.NET) version 18.0.2.169539
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="GoogleChart")]
	[XmlType(TypeName="GoogleChart" , Namespace="mtaKB" )]
	[Serializable]
	public class SdtGoogleChart : GxUserType
	{
		public SdtGoogleChart( )
		{
			/* Constructor for serialization */
		}

		public SdtGoogleChart(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			if (gxTv_SdtGoogleChart_Categories != null)
			{
				AddObjectProperty("Categories", gxTv_SdtGoogleChart_Categories, false);
			}
			if (gxTv_SdtGoogleChart_Series != null)
			{
				AddObjectProperty("Series", gxTv_SdtGoogleChart_Series, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Categories" )]
		[XmlArray(ElementName="Categories"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Categories_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtGoogleChart_Categories == null )
				{
					gxTv_SdtGoogleChart_Categories = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtGoogleChart_Categories;
			}
			set {
				gxTv_SdtGoogleChart_Categories_N = false;
				gxTv_SdtGoogleChart_Categories = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Categories
		{
			get {
				if ( gxTv_SdtGoogleChart_Categories == null )
				{
					gxTv_SdtGoogleChart_Categories = new GxSimpleCollection<string>();
				}
				gxTv_SdtGoogleChart_Categories_N = false;
				return gxTv_SdtGoogleChart_Categories ;
			}
			set {
				gxTv_SdtGoogleChart_Categories_N = false;
				gxTv_SdtGoogleChart_Categories = value;
				SetDirty("Categories");
			}
		}

		public void gxTv_SdtGoogleChart_Categories_SetNull()
		{
			gxTv_SdtGoogleChart_Categories_N = true;
			gxTv_SdtGoogleChart_Categories = null;
		}

		public bool gxTv_SdtGoogleChart_Categories_IsNull()
		{
			return gxTv_SdtGoogleChart_Categories == null;
		}
		public bool ShouldSerializegxTpr_Categories_GxSimpleCollection_Json()
		{
			return gxTv_SdtGoogleChart_Categories != null && gxTv_SdtGoogleChart_Categories.Count > 0;

		}


		[SoapElement(ElementName="Series" )]
		[XmlArray(ElementName="Series"  )]
		[XmlArrayItemAttribute(ElementName="Series" , IsNullable=false )]
		public GXBaseCollection<SdtGoogleChart_Series> gxTpr_Series
		{
			get {
				if ( gxTv_SdtGoogleChart_Series == null )
				{
					gxTv_SdtGoogleChart_Series = new GXBaseCollection<SdtGoogleChart_Series>( context, "GoogleChart.Series", "");
				}
				return gxTv_SdtGoogleChart_Series;
			}
			set {
				gxTv_SdtGoogleChart_Series_N = false;
				gxTv_SdtGoogleChart_Series = value;
				SetDirty("Series");
			}
		}

		public void gxTv_SdtGoogleChart_Series_SetNull()
		{
			gxTv_SdtGoogleChart_Series_N = true;
			gxTv_SdtGoogleChart_Series = null;
		}

		public bool gxTv_SdtGoogleChart_Series_IsNull()
		{
			return gxTv_SdtGoogleChart_Series == null;
		}
		public bool ShouldSerializegxTpr_Series_GxSimpleCollection_Json()
		{
			return gxTv_SdtGoogleChart_Series != null && gxTv_SdtGoogleChart_Series.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Categories_GxSimpleCollection_Json()|| 
				ShouldSerializegxTpr_Series_GxSimpleCollection_Json() || 
				false);
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGoogleChart_Categories_N = true;


			gxTv_SdtGoogleChart_Series_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtGoogleChart_Categories_N;
		protected GxSimpleCollection<string> gxTv_SdtGoogleChart_Categories = null;  
		protected bool gxTv_SdtGoogleChart_Series_N;
		protected GXBaseCollection<SdtGoogleChart_Series> gxTv_SdtGoogleChart_Series = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"GoogleChart", Namespace="mtaKB")]
	public class SdtGoogleChart_RESTInterface : GxGenericCollectionItem<SdtGoogleChart>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGoogleChart_RESTInterface( ) : base()
		{	
		}

		public SdtGoogleChart_RESTInterface( SdtGoogleChart psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Categories", Order=0, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Categories
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Categories_GxSimpleCollection_Json())
					return sdt.gxTpr_Categories;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Categories = value ;
			}
		}

		[DataMember(Name="Series", Order=1, EmitDefaultValue=false)]
		public GxGenericCollection<SdtGoogleChart_Series_RESTInterface> gxTpr_Series
		{
			get {
				if (sdt.ShouldSerializegxTpr_Series_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtGoogleChart_Series_RESTInterface>(sdt.gxTpr_Series);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Series);
			}
		}


		#endregion

		public SdtGoogleChart sdt
		{
			get { 
				return (SdtGoogleChart)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtGoogleChart() ;
			}
		}
	}
	#endregion
}